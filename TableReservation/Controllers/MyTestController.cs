using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TableReservation.Controllers
{
    [ApiController]
    [Route("[controller]/v1")]
    public class MyTestController : ControllerBase
    {
        private ITestService service;

        public MyTestController(ITestService service) 
        {
            this.service = service;
        }

        [HttpGet("First")]
        public IActionResult FirstTest()
        {
            return NoContent();
        }

        [HttpGet("Second")]
        public IActionResult SecondTest()
        {
            return Unauthorized();
        }

        [HttpGet("Third")]
        public IActionResult ThirdTest(int id, string name) 
        {
            return Ok(id);
        }

        [HttpGet("Fourth/{id}/{name}")]
        public IActionResult FourthTest(int id, string name)
        {
            return Ok(name);
        }

        [HttpGet("Fifth/{name}")]
        public IActionResult FifthTest(string name)
        {
            var test = service.GetModelByName(name);

            return Ok(test.Name);
        }
    }
}
