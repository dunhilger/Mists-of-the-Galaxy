using GameStructure;
using DataBaseSource.Entities;
using DataBaseSource;
using MenuStucture.Interfaces;
using MenuStucture;
using Tetris;

namespace StartUp
{
    class Program
    {
        private static Action<IMenuFunctionalityProvider> _noAction = n => { };

        static void Main(string[] args)
        {
            var lightTheme = new MenuTheme()
            {
                FrameColor = ConsoleColor.White,
                BackgroundColor = ConsoleColor.White,
                TextColor = ConsoleColor.Black,
                SelectedTextColor = ConsoleColor.DarkGreen,
                DisabledBackgroundColor = ConsoleColor.White,
                DisabledTextColor = ConsoleColor.Gray,
            };

            var darkTheme = new MenuTheme()
            {
                FrameColor = ConsoleColor.DarkGray,
                TextColor = ConsoleColor.White,
                CursorColor = ConsoleColor.Gray
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

            var menu = new Menu(page_1)
            {
                DisabledItemSelectionMode = DisabledItemSelectionMode.Select,
                NavigationMode = NavigationMode.LoopOn
            };

            DisplayMenu(menu);

            var consoleSettings = new ConsoleSettings();
            consoleSettings.ShowConsoleWindow();

            var grid = new Grid(50, 213);
            var innerGrid = new Grid(20, 10);

            for (int i = 0; i < innerGrid.RowsCount; i++)
            {
                for (int j = 0; j < innerGrid.ColumnsCount; j++)
                {
                    innerGrid[i, j] = new Cell()
                    {
                        Content = new Border()
                        {
                            Visible = false
                        }
                    };
                }
            }

            grid[0, 0] = new Cell() 
            { 
                Content = new Border()
                {
                    Visible = false
                },
                ColumnSpan = 213,
                RowSpan = 3
            }; 

            grid[3, 0] = new Cell()
            {
                Content = new Border()
                {
                    Visible = false
                },
                ColumnSpan = 91,
                RowSpan = 50,
            };

            grid[3, 91] = new Cell()
            {
                Content = new Border()
                {
                    Content = innerGrid,
                },
                ColumnSpan = 32,
                RowSpan = 42
            };

            grid[3, 123] = new Cell()
            {
                Content = new Border()
                {
                    Visible = false
                },
                ColumnSpan = 90,
                RowSpan = 50
            };

            grid[45, 91] = new Cell()
            {
                Content = new Border()
                {
                    Visible = false,
                },
                ColumnSpan = 32,
                RowSpan = 5
            };

            //var consoleRenderer = new ConsoleRenderer(consoleSettings.ConsoleWindowHeight, consoleSettings.ConsoleWindowWidth);
            //consoleRenderer.Render(grid);

            //Тетрис

            //var figureLifeCycle = new FigureLifeCycle(innerGrid);
            //int currentRow = 0;

            //while (true)
            //{
            //    if (currentRow == innerGrid.RowsCount)
            //    {
            //        currentRow = 0;
            //    }

            //    figureLifeCycle.FigureStepDown(currentRow);
            //    currentRow++;
            //    consoleRenderer.Render(grid);
            //    figureLifeCycle.TimerTick();
            //    Console.Clear();
            //}

            //БД
            using (MistsOfTheGalaxyDbContext db = new MistsOfTheGalaxyDbContext())
            {
                // создаем два объекта 
                var planetTitle1 = new ObjectTitle { Title = "Hagro", Id = 17 };
                var planetTitle2 = new ObjectTitle { Title = "Awaya", Id = 26 };
                var planetTitle3 = new ObjectTitle { Title = "Plegata", Id = 106 };
                var planetTitle4 = new ObjectTitle { Title = "Sardarus", Id = 84 };
                var planetTitle5 = new ObjectTitle { Title = "Vionyr", Id = 30 };
                var planetTitle6 = new ObjectTitle { Title = "Quarton", Id = 77 };
                var planetTitle7 = new ObjectTitle { Title = "Mezar", Id = 198 };
                var planetTitle8 = new ObjectTitle { Title = "Kepallon", Id = 14 };
                var planetTitle9 = new ObjectTitle { Title = "Schagart", Id = 2 };
                var planetTitle10 = new ObjectTitle { Title = "Ramwar", Id = 21 };
                var planetTitle11 = new ObjectTitle { Title = "KelGarot", Id = 89 };
                var planetTitle12 = new ObjectTitle { Title = "Artanit", Id = 93 };
                var planetTitle13 = new ObjectTitle { Title = "K-53", Id = 70 };
                var planetTitle14 = new ObjectTitle { Title = "Plymot", Id = 38 };

                // добавляем их в бд
                //db.ObjectTitles.Add(planetTitle1);
                //db.ObjectTitles.Add(planetTitle2);
                //db.ObjectTitles.Add(planetTitle3);
                //db.ObjectTitles.Add(planetTitle4);
                //db.ObjectTitles.Add(planetTitle5);
                //db.ObjectTitles.Add(planetTitle6);
                //db.ObjectTitles.Add(planetTitle7);
                //db.ObjectTitles.Add(planetTitle8);
                //db.ObjectTitles.Add(planetTitle9);
                //db.ObjectTitles.Add(planetTitle10);
                //db.ObjectTitles.Add(planetTitle11);
                //db.ObjectTitles.Add(planetTitle12);
                //db.ObjectTitles.Add(planetTitle13);
                //db.ObjectTitles.Add(planetTitle14);
                //db.SaveChanges();
                //Console.WriteLine("Объекты сохранены");

                //db.ObjectTitles.Remove(planetTitle1);
                //db.ObjectTitles.Remove(planetTitle2);
                //db.SaveChanges();

                // получаем объекты из бд и выводим на консоль
                var planetTitles = db.ObjectTitles.ToList();

                //Console.WriteLine("Список объектов:");
                //foreach (ObjectTitle planet in planetTitles)
                //{
                //    Console.WriteLine($"{planet.Id} - {planet.Title}");
                //}
            }
       
            Console.ReadLine();
        }

        static void DisplayMenu(Menu Menu)
        {
            //int MenuPositionWidth = Console.WindowWidth / 2;
            //int MenuPositionHeigth = Console.WindowHeight / 2;
          
            var MenuBuilder = new ConsoleMenuBuilder(Menu);

            while (true)
            {
                MenuBuilder.RenderMenuPage();
                MenuBuilder.ReadCommand();
                Console.Clear();
            }
        }
    }
}





