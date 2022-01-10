using System;
using System.Collections.Generic;

namespace ConsoleAppExample
{
    public class Menu
    {
        private MenuTheme _theme;

        public MenuTheme Theme
        {
            get { return _theme; }
            set { _theme = value; }
        }

        private List<MenuItem> menuItems;

        public List<MenuItem> MenuItems
        {
            get { return menuItems; }
            set { menuItems = value; }
        }

        private int _menuWidth;

        public int MenuWidth
        {
            get { return _menuWidth; }
            set { _menuWidth = value; }
        }

        private int? cursorPosition = null;

        public Menu(MenuTheme menuTheme, List<MenuItem> menuCommands)
        {
            Theme = menuTheme;
            MenuItems = menuCommands;
            CalculateMenuWidth();
            SetCursorPosition();
        }

        public void CalculateMenuWidth()
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (MenuWidth < MenuItems[i].Name.Length)
                {
                    MenuWidth = MenuItems[i].Name.Length;
                }
            }
            MenuWidth += Theme.Indent;
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

                    if (cursorPosition == i)
                    {
                        SetAccentuationMenuItemColor();
                        SetAccentuationBackgroundColor();
                    }
                    else if (!MenuItems[i].IsEnabled)
                    {
                        SetDisabledMenuItemColor();
                        SetDisabledMenuItemBackGroundColor();                     
                    }
                    else
                    {
                        SetNormalBackgroundColor();
                        SetNormalMenuItemColor();
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

        public void Navigate(Func<int, int> getIndex)
        {
            if (cursorPosition == null || MenuItems.Count == 0) return;

            int i = cursorPosition.Value;

            while (true)
            {
                i = getIndex(i);

                if (i == cursorPosition.Value || MenuItems[i].IsEnabled) break;
            }
            cursorPosition = i;
        }

        public void NavigateUp()
        {
            Navigate(index => 
            {
                index--;

                if (index < 0) index = MenuItems.Count - 1;

                return index;
            });
        }

        public void NavigateDown()
        {
            Navigate(index =>
            {
                index++;

                if (index > MenuItems.Count - 1) index = 0;

                return index;
            });
        }

        public void SetCursorPosition()
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (MenuItems[i].IsEnabled)
                {
                    cursorPosition = i;
                    break;
                }
            }                
        }

        private void SetDisabledMenuItemBackGroundColor() => Console.BackgroundColor = Theme.DisableMenuItemBackGroundColor; 

        private void SetDisabledMenuItemColor() => Console.ForegroundColor = Theme.DisabledMenuItemColor;

        private void SetFrameColor() => Console.ForegroundColor = Theme.FrameColor;       

        private void SetAccentuationMenuItemColor() => Console.ForegroundColor = Theme.AccentFontColor;    

        private void SetAccentuationBackgroundColor() => Console.BackgroundColor = Theme.AccentBackGroundColor;
        
        private void SetNormalMenuItemColor() => Console.ForegroundColor = Theme.NormalFontColor;
        
        private void SetNormalBackgroundColor() => Console.BackgroundColor = Theme.NormalBackGroundColor;
        
        private void ResetColorMenuItem() => Console.ResetColor();       
    }
}
