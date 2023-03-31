using GameStructure;
using System;
using System.Threading;

namespace Tetris
{
    public class FigureLifeCycle
    {
        private int FigurePosition { get; set; }

        private Grid FieldState { get; set; }

        private Grid Grid { get; }

        public FigureLifeCycle(Grid grid)
        {
            Grid = grid;
        }

        public void FigureStepDown(int currentRowIndex)
        {
            if (currentRowIndex == 0)
            {
                FigurePosition = SpawnFigurePosition(Grid.ColumnsCount);
            }

            for (int i = 0; i < Grid.RowsCount; i++)
            {
                for (int j = 0; j < Grid.ColumnsCount; j++)
                {
                    //CheckFilledRows(Grid[i, j]);
                    if (FigurePosition == Grid.RowsCount - 1)
                    {
                        ((Border)Grid[i, j].Content).Visible = true;
                    }

                    if (i == currentRowIndex /*|| FigurePosition == Grid.RowsCount - 1*/)
                    {
                        ((Border)Grid[i, FigurePosition].Content).Visible = true;
                        break;
                    }
                    else
                    {
                        ((Border)Grid[i, j].Content).Visible = false;
                    }
                }
            }
        }

        //private bool CheckFilledRows(Cell cell)
        //{
        //    cell.Content.

        //    return true;
        //}

        private static int SpawnFigurePosition(int columnsCount)
        {
            var random = new Random();
            int spawnPosition = random.Next(columnsCount);

            return spawnPosition;
        }

        public void TimerTick()
        {
            Thread.Sleep(500);
        }

    }
}
