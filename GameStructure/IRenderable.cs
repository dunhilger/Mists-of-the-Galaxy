using System;
using System.Collections.Generic;

namespace GameStructure
{
    public interface IRenderable
    {
        char?[,] Render(int height, int width);
    }
}
