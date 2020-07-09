using CPN.NetCore.Entity.Core.Contract;

namespace CPN.NetCore.Repository.Spec.Core.Contract
{
    public interface IDomainRepository<TDomain, TId> : IRepository
        where TDomain: IDomain<TId>
    {
        
    }
}