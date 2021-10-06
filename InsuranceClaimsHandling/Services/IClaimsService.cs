using InsuranceClaimsHandling.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsHandling
{
    public interface IClaimsService
    {
        public List<LossType> GetAllClaims();
    }
}
