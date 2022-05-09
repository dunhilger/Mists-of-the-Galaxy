using System;

namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Перечисление режимов работы курсора с неактивной командой меню
    /// </summary>
    public enum DisabledItemSelectionMode : byte
    {
        /// <summary>
        /// Режим пропуска
        /// </summary>
        Skip = 0,

        /// <summary>
        /// Режим выделения
        /// </summary>
        Select = 1
    }

    /// <summary>
    /// Перечисление режимов работы навигации курсора
    /// </summary>
    public enum NavigationMode : byte
    {
        /// <summary>
        /// Нециклический
        /// </summary>
        LoopOff = 0,

        /// <summary>
        /// Циклический
        /// </summary>
        LoopOn = 1
    }

    /// <summary>
    /// Класс для создания темы меню
    /// </summary>
    public class MenuTheme
    {
        /// <summary>
        /// Режим навигации курсора
        /// </summary>
        public NavigationMode NavigationMode { get; set; } = NavigationMode.LoopOn;

        /// <summary>
        /// Режим работы курсора с неактивной командой меню
        /// </summary>
        public DisabledItemSelectionMode DisabledItemSelectionMode { get; set; } = DisabledItemSelectionMode.Skip;

        /// <summary>
        /// Горизонтальная линия
        /// </summary>
        public char HorisontalLineElement { get; } = '═';

        /// <summary>
        /// Вертикальная линия
        /// </summary>
        public char VerticalLineElement { get; } = '║';

        /// <summary>
        /// Левый нижний угол
        /// </summary>
        public char LeftBottomCorner { get; } = '╚';

        /// <summary>
        /// Правый нижний угол
        /// </summary>
        public char RightBottomCorner { get; } = '╝';

        /// <summary>
        /// Левый верхний угол
        /// </summary>
        public char LeftUpperCorner { get; } = '╔';

        /// <summary>
        /// Правый верхний угол
        /// </summary>
        public char RightUpperCorner { get; } = '╗';

        /// <summary>
        /// Левый внутренний угол
        /// </summary>
        public char LeftInnerCorner { get; } = '╠';

        /// <summary>
        /// Правый внутренний угол
        /// </summary>
        public char RightInnerCorner { get; } = '╣';

        /// <summary>
        /// Индикатор активированной команды
        /// </summary>
        public char IndicatorActivatedMenuItem { get; } = '√';

        /// <summary>
        /// Цвет рамки меню
        /// </summary>
        public ConsoleColor FrameColor { get; set; } = ConsoleColor.White;

        /// <summary>
        /// Цвет текста
        /// </summary>
        public ConsoleColor TextColor { get; set; } = ConsoleColor.White; 

        /// <summary>
        /// Цвет фона
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;

        /// <summary>
        /// Цвет текста выделенной команды
        /// </summary>
        public ConsoleColor SelectedTextColor { get; set; } = ConsoleColor.Black;

        /// <summary>
        /// Цвет фона выделенной команды
        /// </summary>
        public ConsoleColor SelectedBackgroundColor { get; set; } = ConsoleColor.White; 

        /// <summary>
        /// Цвет текста неактивной команды
        /// </summary>
        public ConsoleColor DisabledTextColor { get; set; } = ConsoleColor.DarkGray; 

        /// <summary>
        /// Цвет фона неактивной команды
        /// </summary>
        public ConsoleColor DisabledBackgroundColor { get; set; } = ConsoleColor.Black; 

        /// <summary>
        /// Цвет текста выделенной неактивной команды
        /// </summary>
        public ConsoleColor SelectedDisabledTextColor { get; set; } = ConsoleColor.DarkGray;

        /// <summary>
        /// Цвет фона выделенной неактивной команды
        /// </summary>
        public ConsoleColor SelectedDisabledBackgroundColor { get; set; } = ConsoleColor.Gray;

        /// <summary>
        /// Отступ слева и справа от имени команды до рамки меню
        /// </summary>
        public int Indent { get; } = 6;
    }
}
