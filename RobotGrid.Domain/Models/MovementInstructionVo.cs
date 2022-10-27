namespace RobotGrid.Domain.Models
{
    public class MovementInstructionVo
    {
        public MovementInstructionVo(GridDimensionsVo gridDimensions, InitialPositionVo initialPosition, string instructions)
        {
            GridDimensions = gridDimensions;
            InitialPosition = initialPosition;
            Instructions = instructions;
        }

        public GridDimensionsVo GridDimensions { get; }
        
        public InitialPositionVo InitialPosition { get; }

        public string Instructions { get; }
    }
}
