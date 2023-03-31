namespace GameStructure
{
    public class Cell
    {
        public Cell()
        {
            RowSpan = 1;
            ColumnSpan = 1;
        }

        public IRenderable Content { get; set; }

        public int RowSpan { get; set; }

        public int ColumnSpan { get; set; }
    }
}
