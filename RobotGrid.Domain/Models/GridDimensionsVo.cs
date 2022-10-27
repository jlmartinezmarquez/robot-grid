namespace RobotGrid.Domain.Models
{
    public class GridDimensionsVo
    {
        public GridDimensionsVo(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        
        public int Y { get; }
    }
}
