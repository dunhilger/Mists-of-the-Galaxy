using MistsOfTheGalaxyMenu.Interfaces;
using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    class Program
    {
        private static Action<MenuNavigator> _noAction = n => { };

        static void Main(string[] args)
        {
            var lightTheme = new MenuTheme()
            {
                FrameColor = ConsoleColor.White,
                BackgroundColor = ConsoleColor.White,
                TextColor = ConsoleColor.Black,
                SelectedTextColor = ConsoleColor.DarkGreen,
                DisabledBackgroundColor = ConsoleColor.White,
                DisabledTextColor = ConsoleColor.Gray
            };

            var darkTheme = new MenuTheme()
            {
                FrameColor = ConsoleColor.DarkGray,
                TextColor = ConsoleColor.White,
                SelectedBackgroundColor = ConsoleColor.Gray
            };
        
            var selectGameMode = new List<IMenuItem>
            {
                new MenuItemOptional("Простой", true, _noAction),
                new MenuItemOptional("Средний", true, _noAction),
                new MenuItemOptional("Сложный", true, _noAction),
                new MenuItem("Назад", true, n => n.TurnToPreviousPage()),
            };
            var page_3 = new MenuPageItemList(selectGameMode);

            var selectMenuTheme = new List<IMenuItem>
            {
                new MenuItemOptional("Светлая", true, d => d.SetTheme(lightTheme)),
                new MenuItemOptional("Темная", true, d => d.SetTheme(darkTheme)),
                new MenuItem("На главную", true, n => n.TurnToMainPage()),
            };
            var page_4 = new MenuPageItemList(selectMenuTheme);

            var mainSettings = new List<IMenuItem>
            {
                new MenuItem("Уровень сложности", true, n => n.NavigateToNextPage(page_3)),
                new MenuItem("Тема", true, n => n.NavigateToNextPage(page_4)),
            };
            var page_2 = new MenuPageItemList(mainSettings);

            var mainMenuCommands = new List<IMenuItem>
            {
                new MenuItem("Новая игра", true, _noAction),
                new MenuItem("Продолжить", false, _noAction),
                new MenuItem("Настройки", true, n => n.NavigateToNextPage(page_2)),
                new MenuItem("Выход", true, n => n.CloseMenu()),
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

    



