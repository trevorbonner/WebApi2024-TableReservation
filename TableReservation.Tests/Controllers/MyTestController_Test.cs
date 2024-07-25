using AutoMapper.Internal;
using Core.Config;
using Core.Interfaces;
using Core.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableReservation.Controllers;

namespace TableReservation.Tests.Controllers
{
    public class MyTestController_Test
    {
        private MyTestController controller;
        private Mock<ITestService> testService;
        private Mock<IOptions<SwaggerSettings>> swaggerSettings;
        private DataContext context;

        public MyTestController_Test()
        {
            testService = new Mock<ITestService>();
            swaggerSettings = new Mock<IOptions<SwaggerSettings>>();
            var dataContextOptions = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("MyMockedDb").Options;
            context = new DataContext(dataContextOptions);

            controller = new MyTestController(testService.Object, swaggerSettings.Object, context);
        }

        [Fact]
        public void TestData()
        {
            var output = controller.TestData();

            Assert.True(output.GetType() == typeof(OkObjectResult));

            var okResult = output as OkObjectResult;
            Assert.True((int)okResult.Value == 1);
        }

        [Theory]
        [MemberData(nameof(TestUnitTests_Data))]
        public void TestUnitTests(TestModel model, Type result)
        {
            var output = controller.TestUnitTests(model);

            Assert.True(output.GetType() == result);
        }

        public static IEnumerable<object[]> TestUnitTests_Data()
        {
            var data = new List<object[]>()
            {
                new object[] {null, typeof(BadRequestResult) },
                new object[] { new TestModel() { Name = "test" }, typeof(NoContentResult)},
                new object[] { new TestModel() { Name = "bob"}, typeof(OkResult) }
            };


            return data;
        }
    }
}
