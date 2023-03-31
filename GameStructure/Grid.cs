using System.Collections.Generic;
using System.Linq;

namespace GameStructure
{
    public class Grid : IRenderable
    {
        private readonly Cell[,] _cells;

        public Grid(int rowsCount, int columnsCount)
        {
            _cells = new Cell[rowsCount, columnsCount];
        }

        public Cell this[int rowIndex, int columnIndex]
        {
            get => _cells[rowIndex, columnIndex];
            set => _cells[rowIndex, columnIndex] = value;
        }

        public int RowsCount =>  _cells.GetLength(0);

        public int ColumnsCount => _cells.GetLength(1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        /// <remarks>
        /// 1. Ширина и высота заданная для области рендеринга не кратна размеру ячеек.(+)
        /// 2. Из метода рендеринга объекта IRenderable был возвращен массив больший по размеру, чем требуемая область.(+)
        /// 3. Из метода рендеринга объекта IRenderable был возвращен массив меньший по размеру, чем требуемая область.(+)
        /// 4. Место для рендеринга закончилось. (+)
        /// </remarks>
        public char?[,] Render(int height, int width)
        {
            char?[,] grid = new char?[height, width];

            List<int> columnsList = GetCellsSidesList(width, ColumnsCount);
            List<int> rowsList = GetCellsSidesList(height, RowsCount);

            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                int heightIndent = rowsList.GetRange(0, i).Sum(); 

                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    if (_cells[i, j]?.Content is not null)
                    {
                        var cell = _cells[i, j];

                        int widthSpan = (j + cell.ColumnSpan > ColumnsCount) ? ColumnsCount - j : cell.ColumnSpan;

                        int heightSpan = (i + cell.RowSpan > RowsCount) ? RowsCount - i : cell.RowSpan;

                        int cellWidth = columnsList.GetRange(j, widthSpan).Sum();

                        int cellHeight = rowsList.GetRange(i, heightSpan).Sum();

                        int widthIndent = columnsList.GetRange(0, j).Sum();

                        var cellCharArray = cellHeight > 0 && cellWidth > 0 ? cell.Content.Render(cellHeight, cellWidth) : null;

                        if (cellCharArray is not null)
                        {
                            int heightCellSize = cellCharArray.GetLength(0) > cellHeight ? cellHeight : cellCharArray.GetLength(0);
                            int widthCellSize = cellCharArray.GetLength(1) > cellWidth ? cellWidth : cellCharArray.GetLength(1);

                            for (int k = 0; k < heightCellSize; k++)
                            {
                                for (int l = 0; l < widthCellSize; l++)
                                {
                                    grid[k + heightIndent, l + widthIndent] = cellCharArray[k, l];
                                }
                            }
                        }
                    }
                }
            }

            return grid;
        }

        private List<int> GetCellsSidesList(int gridSide, int cellCount)    
        {
            List<int> cellsSidesList = new();

            int cellSide = gridSide / cellCount;
            int modulo = gridSide % cellCount;

            for (int i = 0; i < cellCount; i++)
            {
                var side = cellSide;

                if (modulo > 0)
                {
                    side++;
                    modulo--;
                }

                cellsSidesList.Add(side);
            }

            return cellsSidesList;
        }
    }
}
