using RobotGrid.Api.Models;
using RobotGrid.Domain;
using System;

namespace RobotGrid.Api.Services
{
    public class RobotGridService : IRobotGridService
    {
        private readonly IMovement movement;

        public RobotGridService(IMovement movement)
        {
            this.movement = movement;
        }

        public string CalculateFinalPosition(MovementInstructions movementInstructions)
        {


            //foreach(var instruction in movementInstructions.Instructions)
            //{
            //    // TODO: There might be a SOLID way to implement this. I think it's cleaner this way than using a strategy pattern, as the movement methods don't have exactly the same parameters
            //    if (instruction == 'F') movement.MoveUpFront(movementInstructions.InitialPosition)
            //}

            throw new NotImplementedException();
        }
    }
}
