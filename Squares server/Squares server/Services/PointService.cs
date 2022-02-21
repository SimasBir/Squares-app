using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Squares_server.Data;
using Squares_server.Dtos;
using Squares_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares_server.Services
{
    public class PointService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public PointService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ViewPointModel>> GetPointsAsync()
        {
            List<PointModel> allPoints = await _context.Points.ToListAsync();
            List<ViewPointModel> viewPoints = _mapper.Map<List<ViewPointModel>>(allPoints);
            return viewPoints;
        }
        public async Task<List<ViewPointModel>> GetPointsByListAsync(int listId)
        {
            List<NamedListPoint> namedPoints = await _context.NamedListPoints
                .Where(p => p.NamedListId == listId).Include(p => p.PointModel)
                .ToListAsync();
            List<PointModel> allPoints = new List<PointModel>();
            foreach (var point in namedPoints)
            {
                PointModel pointModel = await _context.Points.Where(p => p.Id == point.PointModelId).FirstOrDefaultAsync();
                allPoints.Add(pointModel);
            }
            List<ViewPointModel> viewPoints = _mapper.Map<List<ViewPointModel>>(allPoints);
            return viewPoints;
        }

        public async Task CreatePointListAsync(int listId, List<CreatePointModel> pointList)
        {
            foreach (CreatePointModel point in pointList)
            {
                PointModel pointAdd = await _context.Points.
                    Where(p => p.xCoord == point.xCoord && p.yCoord == point.yCoord).
                    FirstOrDefaultAsync();
                if (pointAdd == null) //add point global point list
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
                    PointModelId = pointAdd.Id,
                    NamedListId = listId
                });
            }
            await _context.SaveChangesAsync();
        }

        //public async Task<ViewPointModel> GetPointAsync(int id)
        //{
        //    PointModel point = await _context.Points.Where(i => i.Id == id).FirstOrDefaultAsync();
        //    if (point == null)
        //    {
        //        throw new ArgumentException($"Point {point.xCoord}.{point.yCoord} not found");
        //    }
        //    ViewPointModel viewPoint = _mapper.Map<ViewPointModel>(point);
        //    return viewPoint;
        //}

        //public async Task<int> CreatePointAsync(CreatePointModel createPointModel)
        //{
        //    PointModel point = _mapper.Map<PointModel>(createPointModel);            
        //    _context.Points.Add(point);
        //    await _context.SaveChangesAsync();
        //    return point.Id;
        //}

        //public async Task DeletePointAsync(int id)
        //{
        //    var point = await _context.Points.Where(i => i.Id == id).FirstOrDefaultAsync();
        //    if (point == null)
        //    {
        //        throw new ArgumentException($"Point id {id} not found");
        //    }
        //    _context.Points.Remove(point);
        //    await _context.SaveChangesAsync();
        //}
    }
}
