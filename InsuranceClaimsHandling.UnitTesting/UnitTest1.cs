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
                {"test","values of test" }
            };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection()
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
            IAuthenticationService service = new AuthenticationService(_dbContext, _configuration);
            // Act
            var result = service.Authentication("usernameDoesntExist", "password");
            // Assert
            Assert.IsNull(result);
        }
        
    }
}