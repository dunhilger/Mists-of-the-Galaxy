using System;
using System.Collections.Generic;
using MistsOfTheGalaxyMenu.Interfaces;
using System.Linq;

namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс для создания меню
    /// </summary>
    public class Menu
    {
        private static List<MenuPageItemList> GetAllMenuPageItemLists(MenuPageItemList menuPage)
        {
            var result = new List<MenuPageItemList>() { menuPage };

            if (menuPage.MenuItems?.Count > 0)
            {
                foreach (var menuItem in menuPage.MenuItems)
                {
                    var nextMenuPage = GetNextMenuPageItemList(menuItem);

                    if (nextMenuPage != null)
                    {
                        var menuPages = GetAllMenuPageItemLists(nextMenuPage);

                        if (menuPages?.Count > 0)
                        {
                            result.AddRange(menuPages);
                        }
                    }
                }
            }
            return result;
        }

        private static MenuPageItemList GetNextMenuPageItemList(IMenuItem menuItem)
        {
            var navigatorParameters = new MenuNavigatorParameters();
            var fakeNavigator = new FakeMenuFunctionalityProvider(navigatorParameters);

            navigatorParameters.MenuPageItemList = null;

            menuItem.NavigatorAction?.Invoke(fakeNavigator);

            if (navigatorParameters.MenuPageItemList != null)
            {
                return navigatorParameters.MenuPageItemList;
            }

            return null;
        }

        private readonly MenuPageSettings _menuPageSettings;

        private readonly MenuFunctionalityProvider _menuFunctionalityProvider;

        /// <summary>
        /// Создание экземпляра <see cref="Menu"/>
        /// </summary>
        /// <param name="menuPageItemList">Список команд страницы меню</param>
        /// <param name="menuTheme">Тема меню</param>
        public Menu(MenuPageItemList menuPageItemList, MenuTheme menuTheme = null)
        {
            _theme = menuTheme ?? new MenuTheme();

            _menuPageSettings = new MenuPageSettings(Theme.NavigationMode, Theme.DisabledItemSelectionMode);

            _menuFunctionalityProvider = new MenuFunctionalityProvider(this);

            var menuPage = new MenuPage(menuPageItemList, _menuPageSettings, _menuFunctionalityProvider);

            MenuPages.Push(menuPage);

            var allMenuPages = GetAllMenuPageItemLists(menuPageItemList);

            MenuWidth = GetMenuWidth(allMenuPages);
        }

        /// <summary>
        /// Ширина страницы меню
        /// </summary>
        public int MenuWidth { get; }

        /// <summary>
        /// Список команд страницы для чтения
        /// </summary>
        public IReadOnlyList<IMenuItem> MenuItems => _menuPage.MenuItems;

        /// <summary>
        /// Выеделнная курсором команда меню
        /// </summary>
        public IMenuItem SelectedMenuItem => _menuPage.SelectedMenuItem;

        /// <summary>
        /// Отмеченная индикатором команда меню
        /// </summary>
        public IMenuItem IndicatedMenuItem => _menuPage.IndicatedMenuItem;

        /// <summary>
        /// Активация команды, выделенной курсором 
        /// </summary>
        public void ActivateItem()
        {
            _menuPage.ActivateItem();
        }

        /// <summary>
        /// Завершение работы меню
        /// </summary>
        public void CloseMenu()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Устанавливает тему меню
        /// </summary>
        /// <param name="theme">Тема меню</param>
        public void SetTheme(MenuTheme theme)
        {
            if (theme != null)
            {
                _theme = theme;
            }
            else
            {
                _theme = new MenuTheme();
            }
        }

        /// <summary>
        /// Создание и переход к следующей странице меню
        /// </summary>
        /// <param name="menuPageItemList">Список команд следующей страницы меню</param>
        public void NavigateToNextPage(MenuPageItemList menuPageItemList)
        {
            MenuPages.Push(new MenuPage(menuPageItemList, _menuPageSettings, _menuFunctionalityProvider));
        }

        /// <summary>
        /// Возврат на предыдущую страницу меню
        /// </summary>
        public void TurnToPreviousPage()
        {
            if (MenuPages.Count > 1)
            {
                MenuPages.Pop();
            }
        }

        /// <summary>
        /// Возврат на главную страницу меню
        /// </summary>
        public void TurnToMainPage()
        {
            while (MenuPages.Count > 1)
            {
                MenuPages.Pop();
            }
        }

        /// <summary>
        /// Навигация по странице вверх
        /// </summary>
        public void NavigateUp()
        {
            _menuPage.NavigateUp();
        }

        /// <summary>
        /// Навигация по странице вниз
        /// </summary>
        public void NavigateDown()
        {
            _menuPage.NavigateDown();
        }

        /// <summary>
        /// Тема меню
        /// </summary>
        public MenuTheme Theme 
        {
            get => _theme;
        }
        private MenuTheme _theme;

        private MenuPage _menuPage => MenuPages.Peek();

        private Stack<MenuPage> MenuPages { get; } = new Stack<MenuPage>();
      
        private int GetMenuWidth(List<MenuPageItemList> allMenuPages)
        {
            return allMenuPages.SelectMany(i => i.MenuItems).Max(i => i.Name.Length) + Theme.Indent;
        }
    }
}
