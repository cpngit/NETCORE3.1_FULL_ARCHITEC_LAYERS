using CPN.NetCore.DTO.Core;
using CPN.NetCore.Entity.Core;
using CPN.NetCore.Repository.Spec.Core.Contract;
using CPN.NetCore.Service.Spec.Core.Contract;

namespace CPN.NetCore.Service.Impl.Core
{
    public abstract class DomainService<TDTO, TDomain, TId> : IDomainService<TDTO, TDomain, TId>
      where TDomain : Domain<TId>
      where TDTO : BaseDTO<TId>
    {
        protected IUnitOfWork UnitOfWork { get; private set; }
        

        public DomainService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}