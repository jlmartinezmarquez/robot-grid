using AutoMapper;
using RobotGrid.Api.Models;
using RobotGrid.Domain;
using RobotGrid.Domain.Models;
using System;

namespace RobotGrid.Api.Services
{
    public class RobotGridService : IRobotGridService
    {
        private readonly IMovement movement;
        private readonly IMapper mapper;

        public RobotGridService(IMovement movement, IMapper mapper)
        {
            this.movement = movement;
            this.mapper = mapper;
        }

        public string CalculateFinalPosition(MovementInstructions movementInstructions)
        {
            var gridDimensionsVo = mapper.Map<GridDimensionsVo>(movementInstructions.GridDimensions);
            var positionVo = mapper.Map<PositionVo>(movementInstructions.InitialPosition);

            foreach (var instruction in movementInstructions.Instructions)
            {
                // TODO: There might be a better SOLID way to implement this. I think it might be cleaner this way instead of having classes with just 1 method each

                positionVo = instruction == 'F'
                    ? movement.MoveUpFront(positionVo)
                    : movement.Face(positionVo, instruction);
            }

            if (movement.CheckWhetherOutOfTheGrid(gridDimensionsVo, positionVo))
            {
                return $"{mapper.Map<string>(positionVo)} LOST";
            }

            return mapper.Map<string>(positionVo);
        }        
    }
}
