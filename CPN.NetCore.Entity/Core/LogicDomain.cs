using System;
using CPN.NetCore.Entity.Core.Contract;

namespace CPN.NetCore.Entity.Core
{
    public abstract class LogicDomain<TId> : Domain<TId>, ILogicDomain
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedBy { get; set; }
    }

}