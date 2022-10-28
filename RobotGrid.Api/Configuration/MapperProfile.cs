using AutoMapper;
using RobotGrid.Api.Models;
using RobotGrid.Domain.Models;

namespace RobotGrid.Api.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GridDimensions, GridDimensionsVo>().ReverseMap();
            CreateMap<Position, PositionVo>().ReverseMap();
            CreateMap<PositionVo, string>().ConstructUsing(p => $"{p.X} {p.Y} {p.Facing}");
        }
    }
}
