using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    public class Menu
    {
        public MenuTheme Theme { get; }
        private int MenuWidth { get; set; }

        private MenuPage MenuPage => MenuPages.Peek();  

        private readonly MenuNavigator _navigator;

        private Stack<MenuPage> MenuPages { get; } = new Stack<MenuPage>();

        public Menu(MenuPageItemList menuPageItemList, MenuTheme menuTheme = null)
        {
            Theme = menuTheme ?? new MenuTheme();
            
            var menuPageSettings = new MenuPageSettings(Theme.NavigationMode, Theme.DisabledItemSelectionMode);

            var menuPage = new MenuPage(menuPageItemList, menuPageSettings);

            MenuPages.Push(menuPage);

            _navigator = new MenuNavigator(this);
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

        public void ActivateItem()
        {
            if (MenuPage.SelectedMenuItem.IsEnabled)
            {
                if (MenuPage.SelectedMenuItem.MenuPageItemList != null)
                {
                    MenuPages.Push(MenuPage.GetMenuPage());
                }
                else
                {
                    MenuPage.SelectedMenuItem?.Action?.Invoke(_navigator);
                }
            }
        }

        public void EnterToNextPage()
        {
            if (MenuPage.SelectedMenuItem.IsEnabled)
            {
                if (MenuPage.SelectedMenuItem.MenuPageItemList != null)
                {
                    MenuPages.Push(MenuPage.GetMenuPage());
                }
            }
        }

        public void TurnToPreviousPage()
        {
            if (MenuPages.Count > 1)
            {
                MenuPages.Pop();
            }                    
        }

        public void TurnToMainPage()
        {
            while (MenuPages.Count > 1)
            {
                MenuPages.Pop();
            }
        }

        public void NavigateUp()
        {
            MenuPage.NavigateUp();
        }

        public void NavigateDown()
        {
            MenuPage.NavigateDown();
        }

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

                    Console.Write($"{leftShift}{MenuPage.MenuItems[i].Name}{rightShift}");
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
