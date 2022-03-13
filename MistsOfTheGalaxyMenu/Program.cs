using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("First Command", false),
                new MenuItem("Second Command", false),
                new MenuItem("Third Command", true),
                new MenuItem("Next Command", true),
                new MenuItem("Last Command", false),
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
                menu.RenderMenu();
                SwitchCommand(menu);
                Console.Clear();
            }
        }

        static void SwitchCommand(Menu menu)
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();

            switch (consoleKey.Key)
            {
                case ConsoleKey.DownArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad2:
                case ConsoleKey.NumPad6:
                    menu.NavigateDown();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.NumPad8:
                case ConsoleKey.NumPad4:
                    menu.NavigateUp();
                    break;
            }
        }
    }
}

    



