namespace RobotGrid.Domain.Models
{
    public class PositionVo
    {
        public PositionVo(int x, int y, char facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        public int X { get; }
        
        public int Y { get; }

        public char Facing { get; }
    }
}
