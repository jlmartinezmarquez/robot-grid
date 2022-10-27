using RobotGrid.Domain.Models;

namespace RobotGrid.Api.Models
{
    public class MovementInstructions
    {
        public GridDimensions GridDimensions { get; set; }

        public Position InitialPosition { get; set; }

        public string Instructions { get; set; }
    }
}
