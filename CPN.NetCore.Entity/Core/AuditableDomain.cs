using System;
using CPN.NetCore.Entity.Core.Contract;

namespace CPN.NetCore.Entity.Core
{
    public abstract class AuditableDomain<TId> : Domain<TId>, IAuditableDomain
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

}