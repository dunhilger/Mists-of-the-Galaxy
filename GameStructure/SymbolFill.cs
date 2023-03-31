namespace GameStructure
{
    public class SymbolFill : IRenderable
    {
        private readonly char _symbol;

        public SymbolFill(char symbol)
        {
            _symbol = symbol;
        }

        public char?[,] Render(int height, int width)
        {
            if (height > 0 && width > 0)
            {
                char?[,] symbolFill = new char?[height, width];

                for (int i = 0; i < symbolFill.GetLength(0); i++)
                {
                    for (int j = 0; j < symbolFill.GetLength(1); j++)
                    {
                        symbolFill[i, j] = _symbol;
                    }
                }

                return symbolFill;
            }

            return null;
        }
    }
}
