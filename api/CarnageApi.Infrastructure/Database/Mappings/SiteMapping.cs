using CarnageApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarnageApi.Infrastructure.Database.Mappings
{
    public class SiteEntityConfiguration : EntityCongurationMapper<Site>
    {
        public override void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.HasKey(c => c.Id);
			builder.ToTable("Site");
        }
    }
}
