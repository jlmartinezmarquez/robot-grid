using AutoMapper;
using RobotGrid.Api.Models;
using RobotGrid.Domain.Models;

namespace RobotGrid.Api.Mappers
{
    public interface IRestMapper
    {
        MovementInstructions FromUrlToMovementInstructions(
            string gridX,
            string gridY,
            string initX,
            string initY,
            string initFacing,
        string instructions);

        GridDimensionsVo ToValueObject(GridDimensions gridDimensions);

        PositionVo ToValueObject(Position position);

        string FromValueObjectToString(PositionVo positionVo);
    }
}