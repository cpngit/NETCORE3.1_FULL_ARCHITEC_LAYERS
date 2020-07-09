using CPN.NetCore.Entity;
using CPN.NetCore.Repository.Impl.Mappings.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPN.NetCore.Repository.Impl.Mappings
{
    public class LnkProfileMap : EntityMapBase<LnkProfile>
    {
        protected override void SetMappings(EntityTypeBuilder<LnkProfile> builder)
        {
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Name).IsRequired().HasMaxLength(250);

        }
    }
}