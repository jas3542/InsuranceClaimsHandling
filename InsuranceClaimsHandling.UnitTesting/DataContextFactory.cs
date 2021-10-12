using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceClaimsHandling.UnitTesting
{
    public class DataContextFactory
    {
        public DataContext getDataDBContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDBContext")
                .Options;
            var dbContext = new DataContext(options);
            return dbContext;
        }
    }
}
