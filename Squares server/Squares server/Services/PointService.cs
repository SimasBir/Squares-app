using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Squares_server.Data;
using Squares_server.Dtos;
using Squares_server.Models;
using Squares_server.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squares_server.Services
{
    public class PointService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly PointModelDtoValidator _validator = new PointModelDtoValidator();

        public PointService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PointModelDto>> GetPointsAsync()
        {
            List<PointModel> allPoints = await _context.Points.ToListAsync();
            List<PointModelDto> viewPoints = _mapper.Map<List<PointModelDto>>(allPoints);
            return viewPoints;
        }
        public async Task<List<PointModelDto>> GetPointsByListAsync(int listId)
        {
            // Could this be done simplier?
            List<NamedListPoint> namedPoints = await _context.NamedListPoints
                .Where(p => p.NamedListId == listId).Include(p => p.PointModel)
                .ToListAsync();

            List<PointModel> allPoints = new List<PointModel>();
            foreach (var point in namedPoints)
            {
                PointModel pointModel = await _context.Points.FirstOrDefaultAsync(p => p.Id == point.PointModelId);
                allPoints.Add(pointModel);
            }
            List<PointModelDto> viewPoints = _mapper.Map<List<PointModelDto>>(allPoints);
            return viewPoints;
        }

        public async Task CreatePointListAsync(int listId, List<PointModelDto> pointList)
        {
            if (pointList.Count > 10000)
            {
                throw new ArgumentException("List cannot be longer than 10000 points");
            }
            foreach (PointModelDto point in pointList)
            {
                _validator.ValidateAndThrow(point);
                PointModel pointAdd = await _context.Points.
                    Where(p => p.xCoord == point.xCoord && p.yCoord == point.yCoord).
                    FirstOrDefaultAsync();

                if (pointAdd == null) //add point to global pointlist
                {
                    PointModel pointNew = new PointModel()
                    {
                        xCoord = point.xCoord,
                        yCoord = point.yCoord
                    };
                    _context.Points.Add(pointNew);
                    await _context.SaveChangesAsync();
                    pointAdd = pointNew; 
                }
                _context.NamedListPoints.Add(new NamedListPoint
                {
                    PointModelId = pointAdd.Id, // Maybe add previous if logic here                    
                    NamedListId = listId
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}
