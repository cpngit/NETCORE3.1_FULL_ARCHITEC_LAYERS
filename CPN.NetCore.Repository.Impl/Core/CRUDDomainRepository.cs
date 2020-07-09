using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CPN.NetCore.Entity.Core;
using CPN.NetCore.Repository.Impl.Context;
using CPN.NetCore.Repository.Spec.Core.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CPN.NetCore.Repository.Impl.Core
{
    public class CRUDDomainRepository<TDomain, TId> : ICRUDDomainRepository<TDomain, TId>
       where TDomain : Domain<TId>
    {
        protected  ApplicationDbContext Context { get; private set;}

        protected DbSet<TDomain> DbSet { get; private set; }
        

        public CRUDDomainRepository(ApplicationDbContext context)
        {
            Context = context;            

            DbSet = Context.Set<TDomain>();
        }

        public void Add(TDomain domain)
        {
            DbSet.Add(domain);
        }

        public void Remove(TDomain domain)
        {
            DbSet.Remove(domain);
        }

        public void Update(TDomain domain)
        {
            DbSet.Update(domain);
        }

        public async Task<TDomain> GetByIdAsync(TId id)
        {
            return await DbSet.FindAsync(id);
        }

        public TDomain GetById(TId id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TDomain> GetAll()
        {
            return DbSet.ToList();
        }

        public async Task<IEnumerable<TDomain>> GetAllAsync()
        {
           return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TDomain>> GetAllNoTrackingAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public IEnumerable<TDomain> GetAllNoTracking()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TDomain>> FindByAsync(Expression<Func<TDomain, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public IEnumerable<TDomain> FindBy(Expression<Func<TDomain, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public async Task<IEnumerable<TDomain>> FindByNoTrackingAsync(Expression<Func<TDomain, bool>> predicate)
        {
            return await DbSet.Where(predicate).AsNoTracking().ToListAsync();
        }

        public IEnumerable<TDomain> FindByNoTracking(Expression<Func<TDomain, bool>> predicate)
        {
            return DbSet.Where(predicate).AsNoTracking().ToList();
        }
    }
}