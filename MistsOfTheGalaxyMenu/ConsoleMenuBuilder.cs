using System;

namespace MenuStucture
{
    /// <summary>
    /// Класс для построения меню в консоли
    /// </summary>
    public class ConsoleMenuBuilder
    {
        private static void ResetColorMenuItem() => Console.ResetColor();

        private readonly Menu _Menu;

        /// <summary>
        /// Создание экземпляра <see cref="ConsoleMenuBuilder"/>
        /// </summary>
        /// <param name="Menu">Объект меню</param>
        public ConsoleMenuBuilder(Menu Menu)
        {
            _Menu = Menu;
        }

        /// <summary>
        /// Отрисовка страниц меню
        /// </summary>
        public void RenderMenuPage()
        {
            if (_Menu.MenuItems.Count > 0)
            {
                String line = new(_Menu.Theme.HorisontalLineElement, _Menu.MenuWidth);
                SetFrameColor();
                Console.WriteLine($"{_Menu.Theme.LeftUpperCorner}{line}{_Menu.Theme.RightUpperCorner}");

                for (int i = 0; i < _Menu.MenuItems.Count; i++)
                {
                    int diff = line.Length - _Menu.MenuItems[i].Name.Length;

                    if (_Menu.IndicatedMenuItem is not null && _Menu.MenuItems[i] == _Menu.IndicatedMenuItem)
                    {
                        diff = line.Length - (_Menu.IndicatedMenuItem.Name.Length + _Menu.Theme.IndicatorActivatedMenuItem.ToString().Length);
                    }

                    String leftShift = new(' ', diff / 2);
                    String rightShift = new(' ', diff - leftShift.Length);

                    Console.Write($"{_Menu.Theme.VerticalLineElement}");

                    if (_Menu.MenuItems[i].IsEnabled)
                    {
                        if (_Menu.SelectedMenuItem == _Menu.MenuItems[i])
                            SetSelectedItemColors();
                        else
                            SetNormalItemColors();
                    }
                    else
                    {
                        if (_Menu.SelectedMenuItem == _Menu.MenuItems[i])
                            SetSelectedDisabledItemColors();
                        else
                            SetDisabledItemColors();
                    }

                    Console.Write($"{leftShift}");

                    if (_Menu.MenuItems[i] == _Menu.IndicatedMenuItem)
                    {
                        Console.Write($"{_Menu.IndicatedMenuItem?.Name}{_Menu.Theme.IndicatorActivatedMenuItem}");
                    }
                    else
                    {
                        Console.Write($"{_Menu.MenuItems[i].Name}");
                    }

                    Console.Write($"{rightShift}");

                    ResetColorMenuItem();
                    SetFrameColor();
                    Console.WriteLine($"{_Menu.Theme.VerticalLineElement}");

                    if (i < _Menu.MenuItems.Count - 1)
                    {
                        Console.WriteLine($"{_Menu.Theme.LeftInnerCorner}{line}{_Menu.Theme.RightInnerCorner}");
                    }
                }
                Console.WriteLine($"{_Menu.Theme.LeftBottomCorner}{line}{_Menu.Theme.RightBottomCorner}");
            }
            else
            {
                Console.WriteLine("no Menu");
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
                    _Menu.NavigateDown();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.NumPad8:
                case ConsoleKey.NumPad4:
                    _Menu.NavigateUp();
                    break;
                case ConsoleKey.Enter:
                    _Menu.ActivateItem();
                    break;
                case ConsoleKey.Backspace:
                    _Menu.TurnToPreviousPage();
                    break;
            }
        }

        private void SetSelectedItemColors()
        {
            Console.ForegroundColor = _Menu.Theme.SelectedTextColor;
            Console.BackgroundColor = _Menu.Theme.CursorColor;
        }

        private void SetDisabledItemColors()
        {
            Console.BackgroundColor = _Menu.Theme.DisabledBackgroundColor;
            Console.ForegroundColor = _Menu.Theme.DisabledTextColor;
        }

        private void SetNormalItemColors()
        {
            Console.ForegroundColor = _Menu.Theme.TextColor;
            Console.BackgroundColor = _Menu.Theme.BackgroundColor;
        }

        private void SetSelectedDisabledItemColors()
        {
            Console.ForegroundColor = _Menu.Theme.SelectedDisabledTextColor;
            Console.BackgroundColor = _Menu.Theme.SelectedDisabledBackgroundColor;
        }
        private void SetFrameColor() => Console.ForegroundColor = _Menu.Theme.FrameColor;
    }
}
