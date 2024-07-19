using Core.Config;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace TableReservation.Controllers
{
    [ApiController]
    [Route("[controller]/v1")]
    public class TableController : ControllerBase
    {
        private ITableService service;

        public TableController(ITableService tableService)
        {
            service = tableService;
        }

        [HttpPost("AddTable")]
        public ActionResult<TableDto> AddTable(TableDto table)
        {
            var addedTable = service.AddTable(table);

            //201 created
            return Created("", addedTable);
        }

        [HttpDelete("DeleteTable")]
        public ActionResult DeleteTableById(int id)
        {
            if(id == 0)
            {
                //Id should be > 0 so returning 400 bad request
                return BadRequest();
            }

            service.DeleteTableById(id);

            //204 things are good but no data to return
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<TableDto>> GetAllTables()
        {
            return Ok(service.GetAllTables());
        }

        [HttpGet("{id}")]
        public ActionResult<TableDto> GetTableById(int id)
        {
            if (id == 0)
            {
                //Id should be > 0 so returning 400 bad request
                return BadRequest();
            }

            var foundTable = service.GetTableById(id);

            if (foundTable == null)
                return NoContent();

            return Ok(foundTable);
        }

        [HttpPut("UpdateTable")]
        public ActionResult UpdateTable(TableDto table)
        {
            service.UpdateTable(table);
            return NoContent();
        }
    }
}
