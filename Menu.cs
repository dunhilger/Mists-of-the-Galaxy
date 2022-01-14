using System;
using System.Collections.Generic;

namespace ConsoleAppExample
{
    public class Menu
    {
        public MenuTheme Theme { get; }

        public List<MenuItem> MenuItems { get; }

        public int MenuWidth { get; }

        private int? cursorPosition = null;

        public Menu(MenuTheme menuTheme, List<MenuItem> menuCommands)
        {
            Theme = menuTheme;
            MenuItems = menuCommands;
            MenuWidth = CalculateMenuWidth();
            SetCursorPosition();
        }

        private int CalculateMenuWidth()
        {
            int getMenuWidth = 0;

            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (getMenuWidth < MenuItems[i].Name.Length)
                {
                    getMenuWidth = MenuItems[i].Name.Length;
                }
            }
            return getMenuWidth += Theme.Indent;
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

                    if (Theme.DisabledItemSelectionType == MenuTheme.ItemSelectionType.Skip)
                    {
                        if (!MenuItems[i].IsEnabled)
                        {
                            SetDisabledMenuItemColor();
                            SetDisabledMenuItemBackGroundColor();
                        }                       
                    }

                    if(Theme.DisabledItemSelectionType == MenuTheme.ItemSelectionType.Select)
                    {
                        if (!MenuItems[i].IsEnabled)
                        {
                            SetNormalBackgroundColor();
                            SetNormalMenuItemColor();
                        }                                                
                    }

                    if (cursorPosition == i)
                    {
                        SetAccentuationMenuItemColor();
                        SetAccentuationBackgroundColor();
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
                i = getIndex(i);

                if (Theme.DisabledItemSelectionType == MenuTheme.ItemSelectionType.Skip)
                {
                    if (i == cursorPosition.Value || MenuItems[i].IsEnabled) break;
                }
                else break;
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

        private void SetCursorPosition()
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (Theme.DisabledItemSelectionType == MenuTheme.ItemSelectionType.Skip)
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
