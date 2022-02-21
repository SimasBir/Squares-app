using AutoMapper;
using Squares_server.Dtos;
using Squares_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares_server.Automapper
{
    public class PointProfile : Profile
    {
        public PointProfile()
        {
            CreateMap<PointModel, CreatePointModel>().ReverseMap();
            CreateMap<PointModel, ViewPointModel>();
            CreateMap<NamedList, CreateNamedList>().ReverseMap();
            CreateMap<NamedList, ViewNamedList>();
        }
    }
}
