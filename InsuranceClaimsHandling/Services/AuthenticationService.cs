﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace InsuranceClaimsHandling
{
    public class AuthenticationService : IAuthenticationService
    {
        private DataContext _dbContext;
        private IConfiguration _configuration;

        public AuthenticationService(DataContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public string Authentication(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
                return null;
            
            var user = _dbContext.Users.SingleOrDefault(x => x.UserName == name);
            
            // checking if the user exists
            if (user == null)
                return null;
            // checking if the passwords match or not
            if (user.Password != password)
                return null;
            // if user is disabled for any reason
            if (!user.Active)
                return null;

            // Generating the token:            
            return generateToken(name);
        }
        
        // Generating the Json token
        private string generateToken(string userName)
        {
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userName)
                    }),
                Expires = DateTime.Now.AddHours(2),
                Issuer = _configuration["jwtIssuer"],
                Audience = _configuration["jwtIssuer"],
                SigningCredentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
