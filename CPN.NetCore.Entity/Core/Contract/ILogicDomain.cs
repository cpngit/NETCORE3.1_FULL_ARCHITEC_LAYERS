using System;

namespace CPN.NetCore.Entity.Core.Contract
{
    public interface ILogicDomain
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedDate { get; set; }

        string DeletedBy { get; set; }
    }
}