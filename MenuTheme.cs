using System;

namespace ConsoleAppExample
{
    public class MenuTheme
    {
        public char HorisontalLineElement { get; } = '═';
        public char VerticalLineElement { get; } = '║';
        public char LeftBottomCorner { get; } = '╚';
        public char RightBottomCorner { get; } = '╝';
        public char LeftUpperCorner { get; } = '╔';
        public char RightUpperCorner { get; } = '╗';
        public char LeftInnerCorner { get; } = '╠';
        public char RightInnerCorner { get; } = '╣';
        public ConsoleColor FrameColor { get; set; } = ConsoleColor.White;
        public ConsoleColor NormalFontColor { get; set; } = ConsoleColor.White;
        public ConsoleColor AccentFontColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor NormalBackGroundColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor AccentBackGroundColor { get; set; } = ConsoleColor.White;
        public ConsoleColor DisabledMenuItemColor { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor DisableMenuItemBackGroundColor { get; set; } = ConsoleColor.Black;  
        public int Indent { get; } = 6;
    }
}
