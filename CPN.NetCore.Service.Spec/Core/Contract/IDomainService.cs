using CPN.NetCore.DTO.Core;
using CPN.NetCore.Entity.Core;

namespace CPN.NetCore.Service.Spec.Core.Contract
{
    public interface IDomainService<TDTO, TDomain, TId> : IService
        where TDomain : Domain<TId>
        where TDTO : BaseDTO<TId>
    {
    }
}