using RobotGrid.Domain;
using System.Collections.Generic;
using System.Linq;

namespace RobotGrid.Api
{
    public class MovementSelector : IMovementSelector
    {
        private readonly IEnumerable<IMovement> movements;

        public MovementSelector(IEnumerable<IMovement> movements)
        {
            this.movements = movements;
        }

        public IMovement GetMovement(char instruction)
        {
            var movementClassName = $"Movement{instruction}";
            var movementClass = movements.FirstOrDefault(x => x.GetType().Name == movementClassName);

            // TODO: Validate it's not null, or use .First() if using an exceptions interceptor

            return movementClass;
        }
    }
}
