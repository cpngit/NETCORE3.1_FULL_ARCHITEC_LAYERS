using System;

namespace CPN.NetCore.Entity.Core.Contract
{
    public interface IAuditableDomain
    {
        string CreatedBy { get; set; } 

        string ModifiedBy { get; set;}

        DateTime CreatedDate { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}