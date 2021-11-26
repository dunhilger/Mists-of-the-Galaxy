using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int _menuWidth;

        public int MenuWidth
        {
            get { return _menuWidth; }
            set { _menuWidth = value; }
        }

        internal Menu(MenuTheme menuTheme, int cursorPosition, List<MenuItem> menuCommands)
        {
            Theme = menuTheme;
            MenuWidth = CalculateMenuWidth(menuCommands);
            RenderMenuFrame(menuCommands, cursorPosition);            
        }

        internal int CalculateMenuWidth(List<MenuItem> commandsMenu)
        {
            int menuWidth = 0;
            int indent = 6;

            for (int i = 0; i < commandsMenu.Count; i++)
            {
                if (menuWidth < commandsMenu[i].Name.Length)
                {
                    menuWidth = commandsMenu[i].Name.Length;
                }
            }
            return menuWidth + indent;
        }

        internal void RenderMenuFrame(List<MenuItem> commands, in int cursorPosition)
        {
            String line = new(Theme.HorisontalLineElement, MenuWidth);
            SetFrameColor();
            Console.WriteLine($"{Theme.LeftUpperCorner}{line}{Theme.RightUpperCorner}");

            for (int i = 0; i < commands.Count; i++)
            {
                int diff = line.Length - commands[i].Name.Length;
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
                
                Console.Write($"{leftShift}{commands[i].Name}{rightShift}");
                ResetColorMenuItem();
                SetFrameColor();
                Console.WriteLine($"{Theme.VerticalLineElement}");

                if (i < commands.Count - 1)
                {
                    Console.WriteLine($"{Theme.LeftInnerCorner}{line}{Theme.RightInnerCorner}");
                }
            }
            Console.WriteLine($"{Theme.LeftBottomCorner}{line}{Theme.RightBottomCorner}");
        }

        public void SetFrameColor()
        {
            Console.ForegroundColor = Theme.FrameColor;
        }

        public void SetAccentuationMenuItem()
        {         
            Console.ForegroundColor = Theme.AccentFontColor;
        }

        public void SetAccentuationBackgroundColor()
        {
            Console.BackgroundColor = Theme.AccentBackGroundColor;
        }
        
        public void SetNormalMenuItem()
        {         
            Console.ForegroundColor = Theme.NormalFontColor;
        }

        public void SetNormalBackgroundColor()
        {
            Console.BackgroundColor = Theme.NormalBackGroundColor;
        }

        public void ResetColorMenuItem()
        {
            Console.ResetColor();
        }
    }
}
