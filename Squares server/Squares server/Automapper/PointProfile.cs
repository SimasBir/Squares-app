using AutoMapper;
using Squares_server.Dtos;
using Squares_server.Models;

namespace Squares_server.Automapper
{
    public class PointProfile : Profile
    {
        public PointProfile()
        {
            CreateMap<PointModel, PointModelDto>().ReverseMap();
            CreateMap<PointModel, PointModelDto>();
            CreateMap<NamedList, CreateNamedList>().ReverseMap();
            CreateMap<NamedList, ViewNamedList>();
        }
    }
}
