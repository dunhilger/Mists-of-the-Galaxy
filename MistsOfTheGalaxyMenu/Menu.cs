using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс для создания меню/Класс типа меню
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Тема меню
        /// </summary>
        public MenuTheme Theme 
        {
            get => _theme;
        }
        private MenuTheme _theme;

        /// <summary>
        /// Ширина страницы меню
        /// </summary>
        public int MenuWidth { get; private set; } 

        private MenuPage MenuPage => MenuPages.Peek();

        private readonly MenuPageSettings _menuPageSettings;

        private Stack<MenuPage> MenuPages { get; } = new Stack<MenuPage>();

        private readonly MenuNavigator _navigator;

        private readonly MenuDecorator _decorator;

        /// <summary>
        /// Создание экземпляра <see cref="Menu"/>
        /// </summary>
        /// <param name="menuPageItemList">Список команд страницы меню</param>
        /// <param name="menuTheme">Тема меню</param>
        public Menu(MenuPageItemList menuPageItemList, MenuTheme menuTheme = null)
        {
            _theme = menuTheme ?? new MenuTheme();

            _menuPageSettings = new MenuPageSettings(Theme.NavigationMode, Theme.DisabledItemSelectionMode);

            _navigator = new MenuNavigator(this);

            _decorator = new MenuDecorator(this);

            var menuPage = new MenuPage(menuPageItemList, _menuPageSettings, _navigator, _decorator);

            MenuPages.Push(menuPage);

            MenuWidth = GetMenuWidth();
        }

        private int GetMenuWidth()
        {
            if (MenuPage.MenuItems.Count > 0)
            {
                int menuWidth = 0;

                for (int i = 0; i < MenuPage.MenuItems.Count; i++)
                {
                    if (menuWidth < MenuPage.MenuItems[i].Name.Length)
                    {
                        menuWidth = MenuPage.MenuItems[i].Name.Length;
                    }
                }
                return menuWidth += Theme.Indent;
            }
            else return 0;
        }

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
        public static void CloseMenu()
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
            MenuPages.Push(new MenuPage(menuPageItemList, _menuPageSettings, _navigator, _decorator));
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
        /// Построение страниц меню
        /// </summary>
        public void RenderMenuPage()
        {
            if (MenuPage.MenuItems.Count > 0)
            {
                MenuWidth = GetMenuWidth();

                String line = new(Theme.HorisontalLineElement, MenuWidth);
                SetFrameColor();
                Console.WriteLine($"{Theme.LeftUpperCorner}{line}{Theme.RightUpperCorner}");

                for (int i = 0; i < MenuPage.MenuItems.Count; i++)
                {
                    int diff = line.Length - MenuPage.MenuItems[i].Name.Length;

                    if (MenuPage.IndicatedMenuItem != null && MenuPage.MenuItems[i] == MenuPage.IndicatedMenuItem)
                    {
                        diff = line.Length - (MenuPage.IndicatedMenuItem.Name.Length + Theme.IndicatorActivatedMenuItem.ToString().Length);
                    }

                    String leftShift = new(' ', diff / 2);
                    String rightShift = new(' ', diff - leftShift.Length);

                    Console.Write($"{Theme.VerticalLineElement}");
                    
                    if (MenuPage.MenuItems[i].IsEnabled)
                    {
                        if (MenuPage.SelectedMenuItem == MenuPage.MenuItems[i]) 
                            SetSelectedItemColors();
                        else
                            SetNormalItemColors();
                    }
                    else
                    {
                        if (MenuPage.SelectedMenuItem == MenuPage.MenuItems[i]) 
                            SetSelectedDisabledItemColors();
                        else
                            SetDisabledItemColors();
                    }

                    Console.Write($"{leftShift}");

                    if (MenuPage.MenuItems[i] == MenuPage.IndicatedMenuItem)
                    {
                        Console.Write($"{MenuPage.IndicatedMenuItem?.Name}{Theme.IndicatorActivatedMenuItem}");
                    }
                    else
                    {
                        Console.Write($"{MenuPage.MenuItems[i].Name}");
                    }

                    Console.Write($"{rightShift}");

                    ResetColorMenuItem();
                    SetFrameColor();
                    Console.WriteLine($"{Theme.VerticalLineElement}");

                    if (i < MenuPage.MenuItems.Count - 1)
                    {
                        Console.WriteLine($"{Theme.LeftInnerCorner}{line}{Theme.RightInnerCorner}");
                    }
                }
                Console.WriteLine($"{Theme.LeftBottomCorner}{line}{Theme.RightBottomCorner}");
            }
            else
            {
                Console.WriteLine("no menu");
            }
        }

        private void SetSelectedItemColors()
        {
            Console.ForegroundColor = Theme.SelectedTextColor;
            Console.BackgroundColor = Theme.SelectedBackgroundColor;
        }

        private void SetDisabledItemColors()
        {
            Console.BackgroundColor = Theme.DisabledBackgroundColor;
            Console.ForegroundColor = Theme.DisabledTextColor;
        }

        private void SetNormalItemColors()
        {
            Console.ForegroundColor = Theme.TextColor;
            Console.BackgroundColor = Theme.BackgroundColor;
        }

        private void SetSelectedDisabledItemColors()
        {
            Console.ForegroundColor = Theme.SelectedDisabledTextColor;
            Console.BackgroundColor = Theme.SelectedDisabledBackgroundColor;
        }
        private void SetFrameColor() => Console.ForegroundColor = Theme.FrameColor;

        private void ResetColorMenuItem() => Console.ResetColor();
    }
}
