using Core.Entities;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService, ISingleton
    {
        private ITokenService tokenService;
        private const string salt = "SomeSuperSecretValue";
        public AuthService(ITokenService tokenService) 
        {
            this.tokenService = tokenService;
        }

        public string Login(LoginDto login)
        {
            var user = new User()
            {
                PasswordHashed = "N+Hej4q4NIkBlMvzYiHg8IzhrNnczgtpB3J4w8glEWQRMahjz+AXuXiqKqp3p5jU6qLdsrtZ+UPS7jyFCL0R+Q=="
            };
            //look in the repo for a username matching the email address.
            //Then compare encrypted values

            var isValid = ValidatePasswordHash(login.Password, user.PasswordHashed);

            return tokenService.CreateToken();
        }

        private bool ValidatePasswordHash(string passwordPlain, string foundUserHash)
        {
            var saltedPassword = passwordPlain + salt;
            var encodedString = string.Empty;

            using (var hashAlg = SHA512.Create())
            {
                var byteArray = Encoding.UTF8.GetBytes(saltedPassword);
                var hash = hashAlg.ComputeHash(byteArray);
                encodedString = Convert.ToBase64String(hash);
            }

            return encodedString == foundUserHash;
        }
    }
}
