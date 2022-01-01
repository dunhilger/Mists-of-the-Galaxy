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

        private int? cursorPosition = 0;

        public Menu(MenuTheme menuTheme, List<MenuItem> menuCommands)
        {
            Theme = menuTheme;
            MenuItems = menuCommands;
            if (MenuItems.Count > 0)
            {
                CalculateMenuWidth();
                CheckActiveStatusMenuItem();
            }         
        }
        
        public void CalculateMenuWidth()
        {
            //int menuWidth = 0;
            const int INDENT = 6;

            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (MenuWidth < MenuItems[i].Name.Length)
                {
                    MenuWidth = MenuItems[i].Name.Length;
                }
            }
            MenuWidth += INDENT;
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
                        SetAccentuationMenuItem();
                        SetAccentuationBackgroundColor();
                    }
                    else
                    {
                        SetNormalBackgroundColor();
                        SetNormalMenuItem();
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

        public void NavigateUp()
        {
            if (cursorPosition == null) return;

            int i = (int)cursorPosition - 1;

            if (i < 0) i = MenuItems.Count - 1; //repeat

            while (i < MenuItems.Count)
            {
                if (MenuItems[i].IsEnabled == false)
                {
                    i--;
                    if (i < 0) i = MenuItems.Count - 1; //repeat
                }
                else
                {
                    cursorPosition = i;
                    break;
                }
            }
        }

        public void NavigateDown()
        {
            if (cursorPosition == null) return;

            int i = (int)cursorPosition + 1;

            if (i > MenuItems.Count - 1) i = 0; //repeat

            while (i < MenuItems.Count)
            {
                if (MenuItems[i].IsEnabled == false)
                {
                    i++;
                    if (i > MenuItems.Count - 1) i = 0; //repeat
                }
                else
                {
                    cursorPosition = i;
                    break;
                }               
            }
        }

        //public void CheckActiveStatusMenuItem()
        //{
        //    int i = (int)cursorPosition;

        //    if (MenuItems.Count > 0)
        //    {
        //        while (i <= MenuItems.Count - 1)
        //        {
        //            if (MenuItems[i].IsEnabled == false)
        //            {
        //                i++;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //            if (i > MenuItems.Count - 1) i = 0;
        //        }
        //        cursorPosition = i;
        //    }
        //}

        public void CheckActiveStatusMenuItem()
        {
            for (int i = (int)cursorPosition; i < MenuItems.Count; )
            {
                if (MenuItems[i].IsEnabled == false)
                {
                    i++;
                }
                else
                {
                    break;
                }
                cursorPosition = i;              
            }
            if (cursorPosition > MenuItems.Count - 1) cursorPosition = null;
        }

        private void SetFrameColor()
        {
            Console.ForegroundColor = Theme.FrameColor;
        }

        private void SetAccentuationMenuItem()
        {         
            Console.ForegroundColor = Theme.AccentFontColor;
        }

        private void SetAccentuationBackgroundColor()
        {
            Console.BackgroundColor = Theme.AccentBackGroundColor;
        }
        
        private void SetNormalMenuItem()
        {         
            Console.ForegroundColor = Theme.NormalFontColor;
        }

        private void SetNormalBackgroundColor()
        {
            Console.BackgroundColor = Theme.NormalBackGroundColor;
        }

        private void ResetColorMenuItem()
        {
            Console.ResetColor();
        }
    }
}
