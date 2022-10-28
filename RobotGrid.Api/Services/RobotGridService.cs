using AutoMapper;
using RobotGrid.Api.ClassSelectors;
using RobotGrid.Api.Mappers;
using RobotGrid.Api.Models;
using RobotGrid.Domain;
using RobotGrid.Domain.Models;
using System;

namespace RobotGrid.Api.Services
{
    public class RobotGridService : IRobotGridService
    {
        private readonly IMovementSelector movementSelector;
        private readonly IRestMapper restMapper;
        private readonly IGridOperations grid;

        public RobotGridService(IMovementSelector movementSelector, IRestMapper restMapper, IGridOperations grid)
        {
            this.movementSelector = movementSelector;
            this.restMapper = restMapper;
            this.grid = grid;
        }

        public string CalculateFinalPosition(MovementInstructions movementInstructions)
        {
            //TODO: to be moved to Mapper class
            var gridDimensionsVo = restMapper.ToValueObject(movementInstructions.GridDimensions);
            var positionVo = restMapper.ToValueObject(movementInstructions.InitialPosition);

            foreach (var instruction in movementInstructions.Instructions)
            {
                var movementClass = movementSelector.GetMovement(instruction);

                positionVo = movementClass.Move(positionVo);
            }

            if (grid.CheckWhetherOutOfTheGrid(gridDimensionsVo, positionVo))
            {
                return $"{restMapper.FromValueObjectToString(positionVo)} LOST";
            }

            return restMapper.FromValueObjectToString(positionVo);
        }        
    }
}
