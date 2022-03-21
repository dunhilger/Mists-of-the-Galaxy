using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    public class Menu
    {
        public MenuTheme Theme { get; }

        public List<MenuItem> MenuItems { get; }

        public int MenuWidth { get; }

        public MenuItem SelectedMenuItem
        {
            get 
            {
                if (cursorPosition.HasValue)
                {
                    return MenuItems[cursorPosition.Value];
                }
                else
                {
                    return null;
                }               
            }
        }

        private int? cursorPosition = null;

        public Menu(List<MenuItem> menuItems, MenuTheme menuTheme = null)
        {
            Theme = menuTheme ?? new MenuTheme();
            MenuItems = menuItems ?? throw new ArgumentNullException(nameof(menuItems));

            MenuWidth = CalculateMenuWidth();
            SetCursorPosition();
        }

        private int CalculateMenuWidth()
        {
            if (MenuItems.Count > 0)
            {
                int menuWidth = 0;

                for (int i = 0; i < MenuItems.Count; i++)
                {
                    if (menuWidth < MenuItems[i].Name.Length)
                    {
                        menuWidth = MenuItems[i].Name.Length;
                    }
                }
                return menuWidth += Theme.Indent;
            }
            else return 0;
        }

        public void RenderMenu()
        {
            if (MenuItems.Count > 0)
            {
                String line = new(Theme.HorisontalLineElement, MenuWidth);
                SetFrameColor();
                Console.WriteLine($"{Theme.LeftUpperCorner}{line}{Theme.RightUpperCorner}");

                for (int i = 0; i < MenuItems.Count; i++)
                {
                    int diff = line.Length - MenuItems[i].Name.Length;
                    String leftShift = new(' ', diff / 2);
                    String rightShift = new(' ', diff - leftShift.Length);

                    Console.Write($"{Theme.VerticalLineElement}");

                    if (MenuItems[i].IsEnabled)
                    {
                        if (cursorPosition == i)
                            SetSelectedItemColors();
                        else
                            SetNormalItemColors();
                    }
                    else
                    {
                        if (cursorPosition == i)
                            SetSelectedDisabledItemColors();
                        else
                            SetDisabledItemColors();
                    }

                    Console.Write($"{leftShift}{MenuItems[i].Name}{rightShift}");
                    ResetColorMenuItem();
                    SetFrameColor();
                    Console.WriteLine($"{Theme.VerticalLineElement}");

                    if (i < MenuItems.Count - 1)
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

        private void Navigate(Func<int, int> getIndex)
        {
            if (cursorPosition == null || MenuItems.Count == 0) return;

            int i = cursorPosition.Value;

            while (true)
            {
                int previousEnabledIndex = i;

                i = getIndex(i);

                if (Theme.DisabledItemSelectionMode == DisabledItemSelectionMode.Skip)
                {
                    if (i == cursorPosition.Value || MenuItems[i].IsEnabled)
                    {
                        break;
                    }
                    else if (i == previousEnabledIndex)
                    {
                        i = cursorPosition.Value;
                        break;
                    }                       
                }
                else
                {
                    break;
                }
            }
            cursorPosition = i;
        }

        public void NavigateUp()
        {
            Navigate(index =>
            {
                index--;

                if (index < 0)
                {
                    switch (Theme.NavigationMode)
                    {
                        case NavigationMode.LoopOff:
                            index++;
                            break;
                        case NavigationMode.LoopOn:
                            index = MenuItems.Count - 1;
                            break;
                    }
                }
                return index;
            });
        }

        public void NavigateDown()
        {
            Navigate(index =>
            {
                index++;

                if (index > MenuItems.Count - 1)
                {
                    switch (Theme.NavigationMode)
                    {
                        case NavigationMode.LoopOff:
                            index--;
                            break;
                        case NavigationMode.LoopOn:
                            index = 0;
                            break;
                    }
                }
                return index;
            });
        }

        private void SetCursorPosition()
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (Theme.DisabledItemSelectionMode == DisabledItemSelectionMode.Skip)
                {
                    if (MenuItems[i].IsEnabled)
                    {
                        cursorPosition = i;
                        break;
                    }
                }
                else
                {
                    cursorPosition = i;
                    break;
                }
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
