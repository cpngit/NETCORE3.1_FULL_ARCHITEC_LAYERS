using CPN.NetCore.Entity.Core;

namespace CPN.NetCore.Entity
{
    public class  LnkProfile : AuditableLogicDomain<int>
    {
        
        public string Name { get; set; }

        public bool Status { get; set; }
    }
}