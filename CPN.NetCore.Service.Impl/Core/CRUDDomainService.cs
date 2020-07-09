using AutoMapper;
using CPN.NetCore.DTO.Core;
using CPN.NetCore.Entity.Core;
using CPN.NetCore.Repository.Spec.Core.Contract;
using CPN.NetCore.Service.Spec.Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CPN.NetCore.Service.Impl.Core
{
    public abstract class CRUDDomainService<TDTO, TDomain, TId> : DomainService<TDTO, TDomain, TId>, ICRUDDomainService<TDTO, TDomain, TId>
     where TDomain: Domain<TId>
     where TDTO : BaseDTO<TId>
    {
        protected ICRUDDomainRepository<TDomain, TId> Repository { get; private set; }
        protected IMapper Mapper { get; private set; }

        public CRUDDomainService(IUnitOfWork unitOfWork, ICRUDDomainRepository<TDomain, TId> repository, IMapper mapper) : base(unitOfWork)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual TDTO Add(TDTO dto)
        {
            var domain = Mapper.Map<TDomain>(dto);

            Repository.Add(domain);

            UnitOfWork.Commit();

            dto = Mapper.Map<TDTO>(domain);

            return dto;
        }

        public virtual IEnumerable<TDTO> GetAll()
        {
            var domains = Repository.GetAll();

            var dtos = Mapper.Map<IEnumerable<TDTO>>(domains);

            return dtos;
        }

        public virtual async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            var domains = await Repository.GetAllAsync();

            var dtos = Mapper.Map<IEnumerable<TDTO>>(domains);

            return dtos;
        }

        public virtual IEnumerable<TDTO> GetAllNoTracking()
        {
            var domains = Repository.GetAllNoTracking();

            var dtos = Mapper.Map<IEnumerable<TDTO>>(domains);

            return dtos;
        }

        public virtual async Task<IEnumerable<TDTO>> GetAllNoTrackingAsync()
        {
            var domains = await Repository.GetAllNoTrackingAsync();

            var dtos = Mapper.Map<IEnumerable<TDTO>>(domains);

            return dtos;
        }

        public virtual TDTO GetById(TId id)
        {
            var domain = Repository.GetById(id);

            var dto = Mapper.Map<TDTO>(domain);

            return dto;
        }

        public virtual async Task<TDTO> GetByIdAsync(TId id)
        {
            var domain = await Repository.GetByIdAsync(id);

            var dto = Mapper.Map<TDTO>(domain);

            return dto;
        }

        public virtual void Remove(TId id)
        {
            var domain = Repository.GetById(id);

            if (domain == null)
                throw new Exception("Domain not found"); // TODO: Define if we'll use exceptions or fluent validations

            Repository.Remove(domain);

            UnitOfWork.Commit();
        }

        public virtual void Update(TId id, TDTO dto)
        {
            var domain = Repository.GetById(id);

            if (domain == null)
                throw new Exception("Domain not found"); // TODO: Define if we'll use exceptions or fluent validations
            
            domain = Mapper.Map<TDTO, TDomain>(dto, domain);

            Repository.Update(domain);

            UnitOfWork.Commit();

        }
    }
}