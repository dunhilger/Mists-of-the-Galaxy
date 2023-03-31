using GameStructure;
using System;

namespace Tetris
{
    public class Figure
    {
        public bool IsEnabled { get; set; }

        public ConsoleColor Color { get; set; } 

        public Cell Pixel { get; set; }

        public Figure()
        {
            Pixel = new Cell();
        }
    }
}
