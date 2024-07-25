using Core.Models;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservation.Tests.Services
{
    public class TestService_Test
    {
        [Fact]
        public void GetModelByName()
        {
            var testService = new TestService();

            var outPut = testService.GetModelByName("test");

            Assert.True(outPut.GetType() == typeof(TestModel));
            Assert.Equal(outPut.Name, "test");
        }
    }
}
