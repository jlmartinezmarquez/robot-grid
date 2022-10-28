using Microsoft.Extensions.Logging;
using RobotGrid.Domain.Models;
using System;

namespace RobotGrid.Domain
{
    public class MovementF : IMovement
    {
        private readonly ILogger<MovementF> logger;

        public MovementF(ILogger<MovementF> logger)
        {
            this.logger = logger;
        }

        public PositionVo Move(PositionVo initialPosition)
        {
            PositionVo finalPosition;

            switch (initialPosition.Facing)
            {
                case 'E':
                    finalPosition = new PositionVo(initialPosition.X + 1, initialPosition.Y, 'E');
                    break;
                case 'S':
                    finalPosition = new PositionVo(initialPosition.X, initialPosition.Y - 1, 'S');
                    break;
                case 'W':
                    finalPosition = new PositionVo(initialPosition.X - 1, initialPosition.Y, 'W');
                    break;
                case 'N':
                    finalPosition = new PositionVo(initialPosition.X, initialPosition.Y + 1, 'N');
                    break;
                default:
                    throw new NotImplementedException();    // TODO: log the error and throw a controlled exception
            }

            logger.LogInformation($"Went FROM X = {initialPosition.X} || Y = {initialPosition.Y} TO X = {finalPosition.X} || Y = {finalPosition.Y}");

            return finalPosition;
        }
    }
}
