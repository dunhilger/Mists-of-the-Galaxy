using System;
using System.Collections.Generic;
using MenuStucture.Interfaces;
using System.Linq;

namespace MenuStucture
{
    /// <summary>
    /// Перечисление режимов работы курсора с неактивной командой меню
    /// </summary>
    public enum DisabledItemSelectionMode : byte
    {
        /// <summary>
        /// Режим пропуска
        /// </summary>
        Skip = 0,

        /// <summary>
        /// Режим выделения
        /// </summary>
        Select = 1
    }

    /// <summary>
    /// Перечисление режимов работы навигации курсора
    /// </summary>
    public enum NavigationMode : byte
    {
        /// <summary>
        /// Нециклический
        /// </summary>
        LoopOn = 0,

        /// <summary>
        /// Циклический
        /// </summary>
        LoopOff = 1
    }

    /// <summary>
    /// Класс для создания меню
    /// </summary>
    public class Menu
    {
        private static List<MenuPageItemList> GetAllMenuPageItemLists(MenuPageItemList MenuPage)
        {
            var result = new List<MenuPageItemList>() { MenuPage };

            if (MenuPage.MenuItems?.Count > 0)
            {
                foreach (var MenuItem in MenuPage.MenuItems)
                {
                    var nextMenuPage = GetNextMenuPageItemList(MenuItem);

                    if (nextMenuPage != null)
                    {
                        var MenuPages = GetAllMenuPageItemLists(nextMenuPage);

                        if (MenuPages?.Count > 0)
                        {
                            result.AddRange(MenuPages);
                        }
                    }
                }
            }
            return result;
        }

        private static MenuPageItemList GetNextMenuPageItemList(IMenuItem MenuItem)
        {
            var navigatorParameters = new MenuNavigatorParameters();
            var fakeNavigator = new FakeMenuFunctionalityProvider(navigatorParameters);

            navigatorParameters.MenuPageItemList = null;

            MenuItem.NavigatorAction?.Invoke(fakeNavigator);

            if (navigatorParameters.MenuPageItemList != null)
            {
                return navigatorParameters.MenuPageItemList;
            }

            return null;
        }

        private readonly MenuPageSettings _menuPageSettings = new(NavigationMode.LoopOff, DisabledItemSelectionMode.Select);


        private readonly MenuFunctionalityProvider _MenuFunctionalityProvider;

        /// <summary>
        /// Режим навигации курсора
        /// </summary>
        public NavigationMode NavigationMode
        {
            get
            {
                return _menuPageSettings.NavigationMode;
            }
            set
            {
                _menuPageSettings.NavigationMode = value;
            }
        }

        /// <summary>
        /// Режим работы курсора с неактивной командой меню
        /// </summary>
        public DisabledItemSelectionMode DisabledItemSelectionMode 
        {
            get
            {
                return _menuPageSettings.DisabledItemSelectionMode;
            }
            set
            {
                _menuPageSettings.DisabledItemSelectionMode = value;
            }
        }

        /// <summary>
        /// Создание экземпляра <see cref="Menu"/>
        /// </summary>
        /// <param name="MenuPageItemList">Список команд страницы меню</param>
        /// <param name="MenuTheme">Тема меню</param>
        public Menu(MenuPageItemList MenuPageItemList, MenuTheme MenuTheme = null)
        {
            _theme = MenuTheme ?? new MenuTheme();

            _MenuFunctionalityProvider = new MenuFunctionalityProvider(this);

            var MenuPage = new MenuPage(MenuPageItemList, _menuPageSettings, _MenuFunctionalityProvider);

            MenuPages.Push(MenuPage);

            var allMenuPages = GetAllMenuPageItemLists(MenuPageItemList);

            MenuWidth = GetMenuWidth(allMenuPages);
        }

        /// <summary>
        /// Ширина страницы меню
        /// </summary>
        public int MenuWidth { get; }

        /// <summary>
        /// Список команд страницы для чтения
        /// </summary>
        public IReadOnlyList<IMenuItem> MenuItems => MenuPage.MenuItems;

        /// <summary>
        /// Выеделнная курсором команда меню
        /// </summary>
        public IMenuItem SelectedMenuItem => MenuPage.SelectedMenuItem;

        /// <summary>
        /// Отмеченная индикатором команда меню
        /// </summary>
        public IMenuItem IndicatedMenuItem => MenuPage.IndicatedMenuItem;

        /// <summary>
        /// Активация команды, выделенной курсором 
        /// </summary>
        public void ActivateItem()
        {
            MenuPage.ActivateItem();
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
        /// <param name="MenuPageItemList">Список команд следующей страницы меню</param>
        public void NavigateToNextPage(MenuPageItemList MenuPageItemList)
        {
            MenuPages.Push(new MenuPage(MenuPageItemList, _menuPageSettings, _MenuFunctionalityProvider));
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
            MenuPage.NavigateUp();
        }

        /// <summary>
        /// Навигация по странице вниз
        /// </summary>
        public void NavigateDown()
        {
            MenuPage.NavigateDown();
        }

        /// <summary>
        /// Тема меню
        /// </summary>
        public MenuTheme Theme 
        {
            get => _theme;
        }
        private MenuTheme _theme;

        private MenuPage MenuPage => MenuPages.Peek();

        private Stack<MenuPage> MenuPages { get; } = new Stack<MenuPage>();
      
        private int GetMenuWidth(List<MenuPageItemList> allMenuPages)
        {
            return allMenuPages.SelectMany(i => i.MenuItems).Max(i => i.Name.Length) + Theme.Indent;
        }
    }
}
