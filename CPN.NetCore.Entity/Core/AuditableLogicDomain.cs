using System;
using CPN.NetCore.Entity.Core.Contract;

namespace CPN.NetCore.Entity.Core
{
    public abstract class AuditableLogicDomain<TId> : Domain<TId>, IAuditableDomain, ILogicDomain
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedBy { get; set; }
    }

}