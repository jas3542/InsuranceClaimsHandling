using InsuranceClaimsHandling.Entities;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceClaimsHandling
{
    public class ClaimsService : IClaimsService
    {
        private DataContext _dbContext;
        
        public ClaimsService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<LossType> GetAllClaims()
        {
            return _dbContext.LossTypes.ToList();
        }
    }
}
