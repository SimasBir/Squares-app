using Microsoft.AspNetCore.Mvc;
using Squares_server.Dtos;
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
    public class NamedListController : ControllerBase
    {
        private NamedListService _namedListService;
        private PointService _pointService;
        public NamedListController(NamedListService namedListService, PointService pointService)
        {
            _namedListService = namedListService;
            _pointService = pointService;
        }

        [HttpGet]
        public async Task<ActionResult> GetNamedLists()
        {
            var namedLists = await _namedListService.GetNamedListsAsync();
            return Ok(namedLists);
        }

        //Pagal RESTFULL "GetPointsByList(int id)" tinkamiau cia:
        [HttpGet("{id}/point")]
        public async Task<ActionResult> GetPointsByList([FromRoute] int id)
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

        [HttpPost]
        public async Task<ActionResult> CreateNamedList(CreateNamedList namedList)
        {
            try
            {
                var namedListData = await _namedListService.CreateNamedListAsync(namedList);
                return Created("NamedList has been created. Id: ", namedListData);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNamedList(int id)
        {
            try
            {
                await _namedListService.DeleteNamedListAsync(id);
                return Ok(id + " has been deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNamedList(int id, List<CreatePointModel> pointList)
        {
            try
            {
                await _pointService.CreatePointListAsync(id, pointList);
                return Created("NamedList has been updated. Id: ", id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
