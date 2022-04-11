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
                new MenuItem("Простой", true, n => n.InsertPlug()),
                new MenuItem("Средний", true, n => n.InsertPlug()),
                new MenuItem("Сложный", true, n => n.InsertPlug()),
                new MenuItem("Назад", true, n => n.TurnToPreviousPage()),
            };
            var page_3 = new MenuPageItemList(selectGameMode);

            var selectMenuTheme = new List<MenuItem>
            {
                new MenuItem("Темная", true, d => d.SwitchOnDarkTheme()),
                new MenuItem("Светлая", true, d => d.SwitchOnLightTheme()),
                new MenuItem("На главную", true, n => n.TurnToMainPage()),
            };
            var page_4 = new MenuPageItemList(selectMenuTheme);

            var mainSettings = new List<MenuItem>
            {
                new MenuItem("Уровень сложности", true, n => n.NavigateToNextPage(page_3)/*, page_3*/),
                new MenuItem("Тема", true, n => n.NavigateToNextPage(page_4)/*, page_4*/),
            };
            var page_2 = new MenuPageItemList(mainSettings);

            var mainMenuCommands = new List<MenuItem>
            {
                new MenuItem("Новая игра", true, n => n.InsertPlug()),
                new MenuItem("Продолжить", false, n => n.InsertPlug()),
                new MenuItem("Настройки", true, n => n.NavigateToNextPage(page_2)/*, page_2*/),
                new MenuItem("Выход", true, n => n.InsertPlug()),
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
                    break;
                case ConsoleKey.Backspace:
                    menu.TurnToPreviousPage();
                    break;
            }
        }
    }
}

    



