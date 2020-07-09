using CPN.NetCore.Entity.Core.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace CPN.NetCore.Repository.Impl.Mappings.Core
{
    public abstract class EntityMapBase<TDomain> : IEntityTypeConfiguration<TDomain>
        where TDomain: class
    {
        public void Configure(EntityTypeBuilder<TDomain> builder)
        {
           SetDeletedProperties(builder);

           SetAuditableProperties(builder);
           
           SetMappings(builder);
        }

        protected abstract void SetMappings(EntityTypeBuilder<TDomain> builder);

        private void SetDeletedProperties(EntityTypeBuilder<TDomain> builder)
        {
            if (!(typeof(TDomain).GetInterfaces().Contains(typeof(ILogicDomain))))
                return;

            builder.Property(nameof(ILogicDomain.DeletedBy));
            builder.Property(nameof(ILogicDomain.DeletedDate));
            builder.Property(nameof(ILogicDomain.IsDeleted));

            builder.HasQueryFilter(p => EF.Property<bool>(p, nameof(ILogicDomain.IsDeleted)) == false);
        }

        private void SetAuditableProperties(EntityTypeBuilder<TDomain> builder)
        {
            if (!(typeof(TDomain).GetInterfaces().Contains(typeof(IAuditableDomain))))
                return;

            builder.Property(nameof(IAuditableDomain.CreatedBy)).IsRequired();
            builder.Property(nameof(IAuditableDomain.CreatedDate)).IsRequired();
            builder.Property(nameof(IAuditableDomain.ModifiedDate)).IsRequired();
            builder.Property(nameof(IAuditableDomain.ModifiedBy)).IsRequired();
        }
    }
}