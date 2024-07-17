using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TestService : ITestService, ITransient
    {
        public TestModel GetModelByName(string name)
        {
            var test = new TestModel()
            {
                Name = name
            };

            return test;
        }
    }
}
