using Core.Interfaces;
using Core.Models;
using Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservation.Tests.Services
{
    public class AuthService_Test
    {
        private Mock<ITokenService> tokenService;
        private AuthService auth;
        public AuthService_Test()
        {
            tokenService = new Mock<ITokenService>();
            auth = new AuthService(tokenService.Object);
        }

        [Fact]
        public void Login()
        {
            var loginDto = new LoginDto();
            tokenService.Setup(x => x.CreateToken()).Returns("testTokenString");

            var loginToken = auth.Login(loginDto);

            Assert.Equal(loginToken, "testTokenString");
        }
    }
}
