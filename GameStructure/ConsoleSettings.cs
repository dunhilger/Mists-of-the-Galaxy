using System;
using System.Runtime.InteropServices;

namespace GameStructure
{
    public class ConsoleSettings
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        
        private static readonly IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int MAXIMIZE = 3;

        public int ConsoleWindowWidth { get; } = Console.LargestWindowWidth;

        public int ConsoleWindowHeight { get; } = Console.LargestWindowHeight;

        public void ShowConsoleWindow()
        {
            Console.SetWindowSize(ConsoleWindowWidth, ConsoleWindowHeight); 
            Console.SetBufferSize(ConsoleWindowWidth, ConsoleWindowHeight);
            Console.Title = "Tetris";
            Console.CursorVisible = false;
            ShowWindow(ThisConsole, MAXIMIZE);    
        }
    }
}
