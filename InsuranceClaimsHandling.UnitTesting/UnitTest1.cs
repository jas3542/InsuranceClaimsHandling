using InsuranceClaimsHandling.Entities;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace InsuranceClaimsHandling.UnitTesting
{
    public class Tests
    {
        private readonly DataContext _dbContext;
        private readonly IConfiguration _configuration;

        public Tests()
        {
            _dbContext = new DataContextFactory().getDataDBContext();

            var myConfiguration = new Dictionary<string,string>
            {
                {"jwtKey","values of test. this can be trust on you. changed for work. To the Desk i went." },
                {"jwtIssuer","testDomain" }
            };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
        }
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void User_should_we_null()
        {
            // Arrange
            User u = new User() { UserName = "test", Password = "123", DisplayName = "test", Active = true };
            _dbContext.Add(u);
            _dbContext.SaveChanges();
            IAuthenticationService service = new AuthenticationService(_dbContext, _configuration);
            // Act
            var result = service.Authentication("usernameDoesntExist", "password");
            // Assert
            Assert.IsNull(result);
        }
        [Test]
        public void User_should_not_we_null()
        {
            // Arrange
            User u = new User() { UserName = "test", Password = "123",DisplayName="test",Active=true };
            _dbContext.Add(u);
            _dbContext.SaveChanges();
            IAuthenticationService service = new AuthenticationService(_dbContext, _configuration);
            // Act
            var token = service.Authentication("test", "123");
            // Assert
            Assert.NotNull(token);
            Assert.IsNotEmpty(token);
        }

    }
}