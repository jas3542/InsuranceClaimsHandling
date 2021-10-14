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
            if (_dbContext.LossTypes.Count() == 0) { 
                _dbContext.LossTypes.Add(new LossType() { LossTypeCode = "1", LossTypeDescription ="1st Description",  LossTypeID = 1});
                _dbContext.LossTypes.Add(new LossType() { LossTypeCode = "2", LossTypeDescription = "2nd Description", LossTypeID = 2 });
                _dbContext.LossTypes.Add(new LossType() { LossTypeCode = "3", LossTypeDescription = "3rd Description", LossTypeID = 3 });
                _dbContext.SaveChanges();
            }
        }

        public List<LossType> GetAllClaims()
        {
            return _dbContext.LossTypes.ToList();
        }
    }
}
