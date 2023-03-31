namespace GameStructure
{
    public class Border : IRenderable
    {
        public IRenderable Content { get; set; }

        public bool Visible { get; set; } = true;

        public char?[,] Render(int height, int width)
        {
            if (height > 0 && width > 0)
            {
                char?[,] border = new char?[height, width];

                char?[,] fill = height > 1 && width > 1 ? Content?.Render(height - 2, width - 2) : null;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (i == 0 || i == height - 1)
                        {
                            if (Visible)
                            {
                                if (j == 0)
                                {
                                    border[i, j] = i == 0 ? LeftUpperCorner : LeftBottomCorner;
                                }
                                else if (j == width - 1)
                                {
                                    border[i, j] = i == 0 ? RightUpperCorner : RightBottomCorner;
                                }
                                else
                                {
                                    border[i, j] = HorisontalLineElement;
                                }
                            }
                        }
                        else
                        {
                            if (j == 0 || j == width - 1)
                            {
                                if (Visible)
                                {
                                    border[i, j] = VerticalLineElement;
                                }
                            }
                            else
                            {
                                if (fill?.GetLength(0) > i - 1 && fill?.GetLength(1) > j - 1)
                                {
                                    border[i, j] = fill[i - 1, j - 1];
                                }
                            }
                        }
                    }
                }

                return border;
            }

            return null;
        }

        private char HorisontalLineElement { get; } = '═';

        private char VerticalLineElement { get; } = '║';

        private char LeftBottomCorner { get; } = '╚';

        private char RightBottomCorner { get; } = '╝';

        private char LeftUpperCorner { get; } = '╔';

        private char RightUpperCorner { get; } = '╗';
    }
}
