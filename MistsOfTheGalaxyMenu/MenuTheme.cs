using System;

namespace MistsOfTheGalaxyMenu
{
    public enum DisabledItemSelectionMode : byte
    {
        Skip = 0,
        Select = 1
    }

    public enum NavigationMode : byte
    {
        LoopOff = 0,
        LoopOn = 1
    }

    public class MenuTheme
    {
        public NavigationMode NavigationMode { get; set; } = NavigationMode.LoopOn;  
        public DisabledItemSelectionMode DisabledItemSelectionMode { get; set; } = DisabledItemSelectionMode.Skip;
        public char HorisontalLineElement { get; } = '═';
        public char VerticalLineElement { get; } = '║';
        public char LeftBottomCorner { get; } = '╚';
        public char RightBottomCorner { get; } = '╝';
        public char LeftUpperCorner { get; } = '╔';
        public char RightUpperCorner { get; } = '╗';
        public char LeftInnerCorner { get; } = '╠';
        public char RightInnerCorner { get; } = '╣';
        public ConsoleColor FrameColor { get; set; } = ConsoleColor.White;
        public ConsoleColor TextColor { get; set; } = ConsoleColor.White; 
        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor SelectedTextColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor SelectedBackgroundColor { get; set; } = ConsoleColor.White; 
        public ConsoleColor DisabledTextColor { get; set; } = ConsoleColor.DarkGray; 
        public ConsoleColor DisabledBackgroundColor { get; set; } = ConsoleColor.Black; 
        public ConsoleColor SelectedDisabledTextColor { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor SelectedDisabledBackgroundColor { get; set; } = ConsoleColor.Gray;
        public int Indent { get; } = 6;
    }
}
