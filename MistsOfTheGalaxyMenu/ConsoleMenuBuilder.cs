using System;

namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс для построения меню в консоли
    /// </summary>
    public class ConsoleMenuBuilder
    {
        private static void ResetColorMenuItem() => Console.ResetColor();

        private readonly Menu _menu;

        /// <summary>
        /// Создание экземпляра <see cref="ConsoleMenuBuilder"/>
        /// </summary>
        /// <param name="menu">Объект меню</param>
        public ConsoleMenuBuilder(Menu menu)
        {
            _menu = menu;
        }

        /// <summary>
        /// Отрисовка страниц меню
        /// </summary>
        public void RenderMenuPage()
        {
            if (_menu.MenuItems.Count > 0)
            {
                String line = new(_menu.Theme.HorisontalLineElement, _menu.MenuWidth);
                SetFrameColor();
                Console.WriteLine($"{_menu.Theme.LeftUpperCorner}{line}{_menu.Theme.RightUpperCorner}");

                for (int i = 0; i < _menu.MenuItems.Count; i++)
                {
                    int diff = line.Length - _menu.MenuItems[i].Name.Length;

                    if (_menu.IndicatedMenuItem is not null && _menu.MenuItems[i] == _menu.IndicatedMenuItem)
                    {
                        diff = line.Length - (_menu.IndicatedMenuItem.Name.Length + _menu.Theme.IndicatorActivatedMenuItem.ToString().Length);
                    }

                    String leftShift = new(' ', diff / 2);
                    String rightShift = new(' ', diff - leftShift.Length);

                    Console.Write($"{_menu.Theme.VerticalLineElement}");

                    if (_menu.MenuItems[i].IsEnabled)
                    {
                        if (_menu.SelectedMenuItem == _menu.MenuItems[i])
                            SetSelectedItemColors();
                        else
                            SetNormalItemColors();
                    }
                    else
                    {
                        if (_menu.SelectedMenuItem == _menu.MenuItems[i])
                            SetSelectedDisabledItemColors();
                        else
                            SetDisabledItemColors();
                    }

                    Console.Write($"{leftShift}");

                    if (_menu.MenuItems[i] == _menu.IndicatedMenuItem)
                    {
                        Console.Write($"{_menu.IndicatedMenuItem?.Name}{_menu.Theme.IndicatorActivatedMenuItem}");
                    }
                    else
                    {
                        Console.Write($"{_menu.MenuItems[i].Name}");
                    }

                    Console.Write($"{rightShift}");

                    ResetColorMenuItem();
                    SetFrameColor();
                    Console.WriteLine($"{_menu.Theme.VerticalLineElement}");

                    if (i < _menu.MenuItems.Count - 1)
                    {
                        Console.WriteLine($"{_menu.Theme.LeftInnerCorner}{line}{_menu.Theme.RightInnerCorner}");
                    }
                }
                Console.WriteLine($"{_menu.Theme.LeftBottomCorner}{line}{_menu.Theme.RightBottomCorner}");
            }
            else
            {
                Console.WriteLine("no menu");
            }
        }

        /// <summary>
        /// Распознает команды клавиатуры
        /// </summary>
        public void ReadCommand()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();

            switch (consoleKey.Key)
            {
                case ConsoleKey.DownArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad2:
                case ConsoleKey.NumPad6:
                    _menu.NavigateDown();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.NumPad8:
                case ConsoleKey.NumPad4:
                    _menu.NavigateUp();
                    break;
                case ConsoleKey.Enter:
                    _menu.ActivateItem();
                    break;
                case ConsoleKey.Backspace:
                    _menu.TurnToPreviousPage();
                    break;
            }
        }

        private void SetSelectedItemColors()
        {
            Console.ForegroundColor = _menu.Theme.SelectedTextColor;
            Console.BackgroundColor = _menu.Theme.SelectedBackgroundColor;
        }

        private void SetDisabledItemColors()
        {
            Console.BackgroundColor = _menu.Theme.DisabledBackgroundColor;
            Console.ForegroundColor = _menu.Theme.DisabledTextColor;
        }

        private void SetNormalItemColors()
        {
            Console.ForegroundColor = _menu.Theme.TextColor;
            Console.BackgroundColor = _menu.Theme.BackgroundColor;
        }

        private void SetSelectedDisabledItemColors()
        {
            Console.ForegroundColor = _menu.Theme.SelectedDisabledTextColor;
            Console.BackgroundColor = _menu.Theme.SelectedDisabledBackgroundColor;
        }
        private void SetFrameColor() => Console.ForegroundColor = _menu.Theme.FrameColor;
    }
}
