using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExample
{
    public class MenuTheme
    {
        public char HorisontalLineElement { get; set; } = '═';
        public char VerticalLineElement { get; set; } = '║';
        public char LeftBottomCorner { get; set; } = '╚';
        public char RightBottomCorner { get; set; } = '╝';
        public char LeftUpperCorner { get; set; } = '╔';
        public char RightUpperCorner { get; set; } = '╗';
        public char LeftInnerCorner { get; set; } = '╠';
        public char RightInnerCorner { get; set; } = '╣';
        public ConsoleColor FrameColor { get; set; } = ConsoleColor.White;
        public ConsoleColor NormalFontColor { get; set; } = ConsoleColor.White;
        public ConsoleColor AccentFontColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor NormalBackGroundColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor AccentBackGroundColor { get; set; } = ConsoleColor.White;    
    }
}
