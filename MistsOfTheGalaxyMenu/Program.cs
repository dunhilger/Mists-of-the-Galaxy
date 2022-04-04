using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            var selectGameMode = new List<MenuItem>
            {
                new MenuItem("Простой", true),
                new MenuItem("Средний", true),
                new MenuItem("Сложный", true),
                new MenuItem("Назад", true, n => n.TurnToPreviousPage()),
            };
            var page_3 = new MenuPageItemList(selectGameMode);

            var selectMenuTheme = new List<MenuItem>
            {
                new MenuItem("Темная", true),
                new MenuItem("Светлая", true),
                new MenuItem("На главную", true, n => n.TurnToMainPage()),
            };
            var page_4 = new MenuPageItemList(selectMenuTheme);

            var mainSettings = new List<MenuItem>
            {
                new MenuItem("Уровень сложности", true, page_3),
                new MenuItem("Тема", true, page_4),
            };
            var page_2 = new MenuPageItemList(mainSettings);

            var mainMenuCommands = new List<MenuItem>
            {
                new MenuItem("Новая игра", true),
                new MenuItem("Продолжить", false),
                new MenuItem("Настройки", true, page_2),
                new MenuItem("Выход", true),
            };
            var page_1 = new MenuPageItemList(mainMenuCommands);

            var menu = new Menu(page_1);

            DisplayMenu(menu);
        }

        static void DisplayMenu(Menu menu)
        {
            //int menuPositionWidth = Console.WindowWidth / 2;
            //int menuPositionHeigth = Console.WindowHeight / 2;
            Console.CursorVisible = false;
            
            while (true)
            {
                menu.RenderMenuPage();
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
                case ConsoleKey.Enter:
                    menu.ActivateItem();
                    //menu.EnterToNextPage();
                    break;
                case ConsoleKey.Backspace:
                    menu.TurnToPreviousPage();
                    break;
            }
        }
    }
}

    



