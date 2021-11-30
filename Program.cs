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
            //int menuPositionWidth = Console.WindowWidth / 2;
            //int menuPositionHeigth = Console.WindowHeight / 2;
            Console.CursorVisible = false;
            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, commands);

            while (true)
            {
                menu.RenderMenu(commands);
                SwitchCommand(menu, commands);

                Console.Clear();
            }
        }

        static void SwitchCommand(Menu menu, in List<MenuItem> commands)
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();

            switch (consoleKey.Key)
            {
                case ConsoleKey.DownArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad2:
                case ConsoleKey.NumPad6:
                    menu.NavigateDown(commands);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.NumPad8:
                case ConsoleKey.NumPad4:
                    menu.NavigateUp(commands);
                    break;
            }
        }
    }
}

    



