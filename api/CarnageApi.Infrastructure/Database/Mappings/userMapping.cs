using CarnageApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarnageApi.Infrastructure.Database.Mappings
{
    public class UserEntityConfiguration : EntityCongurationMapper<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);
			builder.ToTable("User");
        }
    }
}
