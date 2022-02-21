using Microsoft.AspNetCore.Mvc;
using Squares_server.Dtos;
using Squares_server.Models;
using Squares_server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares_server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private PointService _pointService;
        public PointController(PointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPoints()
        {
            var points = await _pointService.GetPointsAsync();
            return Ok(points);
        }

        [HttpGet("{id}")]
        //[HttpGet("{xCoord}/{yCoord}")]
        //public async Task<ActionResult> GetPoint([FromRoute] int xCoord, [FromRoute] int yCoord)
        public async Task<ActionResult> GetPointsByList(int id)
        {
            try
            {
                var point = await _pointService.GetPointsByListAsync(id);
                return Ok(point);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<ActionResult> CreatePoint(CreatePointModel point)
        //{
        //    try
        //    {
        //        var pointData = await _pointService.CreatePointAsync(point);
        //        return Created("Point has been created. Id: ", pointData);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePoint(int id)
        //{
        //    try
        //    {
        //        await _pointService.DeletePointAsync(id);
        //        return Ok(id + " has been deleted");
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdatePoint(int id, PointModel point)
        //{
        //    try
        //    {
        //        var createdId = await _pointService.UpdatePointAsync(id, point);
        //        return Created("Point has been updated. Id: ", createdId);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
