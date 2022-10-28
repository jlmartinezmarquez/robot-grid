using AutoMapper;
using RobotGrid.Api.Models;
using RobotGrid.Domain;
using RobotGrid.Domain.Models;
using System;

namespace RobotGrid.Api.Services
{
    public class RobotGridService : IRobotGridService
    {
        private readonly IMovementSelector movementSelector;
        private readonly IMapper mapper;
        private readonly IGridOperations grid;

        public RobotGridService(IMovementSelector movementSelector, IMapper mapper, IGridOperations grid)
        {
            this.movementSelector = movementSelector;
            this.mapper = mapper;
            this.grid = grid;
        }

        public string CalculateFinalPosition(MovementInstructions movementInstructions)
        {
            //TODO: to be moved to Mapper class
            var gridDimensionsVo = mapper.Map<GridDimensionsVo>(movementInstructions.GridDimensions);
            var positionVo = mapper.Map<PositionVo>(movementInstructions.InitialPosition);


            foreach (var instruction in movementInstructions.Instructions)
            {
                var movementClass = movementSelector.GetMovement(instruction);

                positionVo = movementClass.Move(positionVo);
            }

            if (grid.CheckWhetherOutOfTheGrid(gridDimensionsVo, positionVo))
            {
                return $"{mapper.Map<string>(positionVo)} LOST";
            }

            return mapper.Map<string>(positionVo);
        }        
    }
}
