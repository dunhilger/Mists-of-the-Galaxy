using System;
using System.Text;

namespace GameStructure
{
    public class ConsoleRenderer
    {
        private readonly int _width;

        private readonly int _height;

        public ConsoleRenderer(int heigth, int width)
        {
            _height = heigth > 0 ? heigth : throw new ArgumentException(nameof(heigth));

            _width = width > 0 ? width : throw new ArgumentException(nameof(width));
        }

        public void Render(IRenderable renderable)
        {
            var renderResult = renderable?.Render(_height, _width);

            if (renderResult is not null)
            {
                for (int i = 0; i < renderResult.GetLength(0); i++)
                {
                    var sb = new StringBuilder();

                    for (int j = 0; j < renderResult.GetLength(1); j++)
                    {
                        sb.Append(renderResult[i, j] ?? ' ');
                    }
                    Console.WriteLine(sb.ToString());
                }
            }
        }
    }
}
