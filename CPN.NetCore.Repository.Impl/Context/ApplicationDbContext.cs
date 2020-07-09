using CPN.NetCore.Entity.Core.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPN.NetCore.Repository.Impl.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateCommonPropertiesStatus();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
                                              System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) 
        {
            UpdateCommonPropertiesStatus();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateCommonPropertiesStatus() // TODO: Move To Strategy Class
        {

            //foreach(var domain in ChangeTracker.Entries().Where(x => x is ILogicDomain || x is IAuditableDomain))
            foreach(var domain in ChangeTracker.Entries())
            {
                   if (domain.Entity is ILogicDomain)
                        UpdateLogicDomainProperties(domain);

                    if (domain.Entity is IAuditableDomain)
                        UpdateAuditableDomainProperties(domain);
                   
            }
        }

        private void UpdateLogicDomainProperties(EntityEntry domain)
        {
                switch(domain.State)
                {
                    case EntityState.Added:
                        domain.CurrentValues[nameof(ILogicDomain.IsDeleted)] = false;
                        domain.CurrentValues[nameof(ILogicDomain.DeletedBy)] = string.Empty; // TODO: Set username
                        domain.CurrentValues[nameof(ILogicDomain.DeletedDate)] = null; 
                        break;
                    case EntityState.Deleted:
                        domain.CurrentValues[nameof(ILogicDomain.IsDeleted)] = true;
                        domain.CurrentValues[nameof(ILogicDomain.DeletedBy)] = string.Empty; // TODO: Set username
                        domain.CurrentValues[nameof(ILogicDomain.DeletedDate)] = DateTime.UtcNow;
                        domain.State = EntityState.Modified;
                        break;
                }
        }

        private void UpdateAuditableDomainProperties(EntityEntry domain)
        {
                switch(domain.State)
                {
                    case EntityState.Added:
                        domain.CurrentValues[nameof(IAuditableDomain.CreatedBy)] = ""; // TODO: Set username
                        domain.CurrentValues[nameof(IAuditableDomain.ModifiedBy)] = ""; // TODO: Set username
                        domain.CurrentValues[nameof(IAuditableDomain.CreatedDate)] = DateTime.UtcNow; 
                        domain.CurrentValues[nameof(IAuditableDomain.ModifiedDate)] = DateTime.UtcNow; 
                        break;
                    case EntityState.Modified:                      
                        domain.CurrentValues[nameof(IAuditableDomain.ModifiedBy)] = ""; // TODO: Set username
                        domain.CurrentValues[nameof(IAuditableDomain.ModifiedDate)] = DateTime.UtcNow;
                        domain.CurrentValues[nameof(IAuditableDomain.CreatedDate)] = domain.OriginalValues[nameof(IAuditableDomain.CreatedDate)];
                        domain.CurrentValues[nameof(IAuditableDomain.CreatedBy)] = domain.OriginalValues[nameof(IAuditableDomain.CreatedBy)];
                    break;
                }
        }

    }
}