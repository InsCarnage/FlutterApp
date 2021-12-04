using CarnageApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarnageApi.Infrastructure.Database.Mappings
{
    public class PermissionEntityConfiguration : EntityCongurationMapper<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(c => c.Id);
			builder.ToTable("Permission");
        }
    }
}
