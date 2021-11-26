using System;
using System.Collections.Generic;

namespace ConsoleAppExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("First Command"),
                new MenuItem("Second Command"),
                new MenuItem("Third Command"),
                new MenuItem("Next Command"),
                new MenuItem("Last Command"),
            };

            DisplayMenu(in menuItems);
        }

        static void DisplayMenu(in List<MenuItem> commands)
        {
            int menuPositionWidth = Console.WindowWidth / 2;
            int menuPositionHeigth = Console.WindowHeight / 2;
            int cursorPosition = 0;
            Console.CursorVisible = false;

            while (true)
            {
                MenuTheme menuTheme = new MenuTheme();
                //menuTheme.FrameColor = ConsoleColor.DarkYellow;
                //menuTheme.NormalFontColor = ConsoleColor.Yellow;
                //menuTheme.NormalBackGroundColor = ConsoleColor.Black;
                //menuTheme.AccentBackGroundColor = ConsoleColor.DarkYellow;
                //menuTheme.AccentFontColor = ConsoleColor.DarkRed;
                Menu menu = new Menu(menuTheme, cursorPosition, commands);
                SwitchCommand(ref cursorPosition);
                //Console.SetCursorPosition(menuPositionWidth, menuPositionHeigth);
                if (cursorPosition > commands.Count - 1) cursorPosition = 0;
                if (cursorPosition < 0) cursorPosition = commands.Count - 1;
                Console.Clear();
            }
        }

        static void SwitchCommand(ref int positionCursor)
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();

            switch (consoleKey.Key)
            {
                case ConsoleKey.DownArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad2:
                case ConsoleKey.NumPad6:                  
                    positionCursor++;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.NumPad8:
                case ConsoleKey.NumPad4:
                    positionCursor--;
                    break;
            }
        }
    }
}

    



