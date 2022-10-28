using AutoMapper;
using RobotGrid.Api.Models;
using RobotGrid.Domain.Models;

namespace RobotGrid.Api.Mappers
{
    public class RestMapper : IRestMapper
    {
        private readonly IMapper mapper;

        public RestMapper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public MovementInstructions FromUrlToMovementInstructions(
            string gridX,
            string gridY,
            string initX,
            string initY,
            string initFacing,
            string instructions)
        {
            return new MovementInstructions
            {
                GridDimensions = new GridDimensions
                {
                    X = int.Parse(gridX),
                    Y = int.Parse(gridY)
                },
                Instructions = instructions,
                InitialPosition = new Position
                {
                    X = int.Parse(initX),
                    Y = int.Parse(initY),
                    Facing = initFacing[0]
                }
            };
        }

        public GridDimensionsVo ToValueObject(GridDimensions gridDimensions) => mapper.Map<GridDimensionsVo>(gridDimensions);
        
        public PositionVo ToValueObject(Position position) => mapper.Map<PositionVo>(position);

        public string FromValueObjectToString(PositionVo positionVo) => mapper.Map<string>(positionVo);
    }
}