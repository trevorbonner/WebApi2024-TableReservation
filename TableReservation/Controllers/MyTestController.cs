using Core.Config;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TableReservation.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]/v1")]
    public class MyTestController : ControllerBase
    {
        private ITestService service;
        private DataContext context;
        public MyTestController(ITestService service, IOptions<SwaggerSettings> options, DataContext context) 
        {
            this.service = service;
            this.context = context;
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

        [AllowAnonymous]
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

        [HttpGet("TestData")]
        public IActionResult TestData()
        {
            var users = context.Users.ToList();

            var user = new User()
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                PhoneNumber = "Test",
                PasswordHashed = "SomeHash"
            };

            context.Users.Add(user);
            context.SaveChanges();

            return Ok(user.Id);
        }

        public IActionResult TestUnitTests(TestModel testModel)
        {
            if(testModel == null)
            {
                return BadRequest();
            }

            if(testModel.Name == "test")
            {
                return NoContent();
            }

            return Ok();

        }
    }
}
