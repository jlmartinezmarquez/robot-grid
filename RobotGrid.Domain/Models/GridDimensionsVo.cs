namespace RobotGrid.Domain.Models
{
    public class GridDimensionsVo
    {
        public GridDimensionsVo(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        
        public int Height { get; }
    }
}
