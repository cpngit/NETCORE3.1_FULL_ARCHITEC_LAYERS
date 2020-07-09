using CPN.NetCore.DTO.Core;
using CPN.NetCore.Entity.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CPN.NetCore.Service.Spec.Core.Contract
{
    public interface ICRUDDomainService<TDTO, TDomain, TId> : IDomainService<TDTO, TDomain, TId>
        where TDomain : Domain<TId>
        where TDTO : BaseDTO<TId>
    {
        Task<TDTO> GetByIdAsync(TId id); 
      
        TDTO GetById(TId id);
        
        IEnumerable<TDTO> GetAll();

        Task<IEnumerable<TDTO>> GetAllAsync();

        Task<IEnumerable<TDTO>> GetAllNoTrackingAsync();

        IEnumerable<TDTO> GetAllNoTracking();


        TDTO Add(TDTO dto);
        void Update(TId id, TDTO dto);
        void Remove(TId id);
    }
}