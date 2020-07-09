using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CPN.NetCore.Entity.Core.Contract;

namespace CPN.NetCore.Repository.Spec.Core.Contract
{
    public interface ICRUDDomainRepository<TDomain, TId> : IDomainRepository<TDomain, TId>
       where TDomain: IDomain<TId>
    {
        Task<TDomain> GetByIdAsync(TId id);
        
        TDomain GetById(TId id);
        
        IEnumerable<TDomain> GetAll();

        Task<IEnumerable<TDomain>> GetAllAsync();

        Task<IEnumerable<TDomain>> GetAllNoTrackingAsync();

        IEnumerable<TDomain> GetAllNoTracking();

        Task<IEnumerable<TDomain>> FindByAsync(Expression<Func<TDomain, bool>> predicate);

        IEnumerable<TDomain> FindBy(Expression<Func<TDomain, bool>> predicate);

        Task<IEnumerable<TDomain>> FindByNoTrackingAsync(Expression<Func<TDomain, bool>> predicate);

        IEnumerable<TDomain> FindByNoTracking(Expression<Func<TDomain, bool>> predicate);

        void Add(TDomain domain);
        void Update(TDomain domain);
        void Remove(TDomain domain);
    }
}