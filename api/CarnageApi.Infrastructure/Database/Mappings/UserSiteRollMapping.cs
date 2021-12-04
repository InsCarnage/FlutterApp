using CarnageApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarnageApi.Infrastructure.Database.Mappings
{
    public class UserSiteRollEntityConfiguration : EntityCongurationMapper<UserSiteRoll>
    {
        public override void Configure(EntityTypeBuilder<UserSiteRoll> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(x=>x.User).WithMany(d=>d.UserSiteRoll).HasForeignKey(e=>e.UserId).HasPrincipalKey(g => g.Id);

            builder.HasOne(x=>x.Site).WithMany(d=>d.UserSiteRoll).HasForeignKey(e=>e.SiteId).HasPrincipalKey(g => g.Id);

            builder.HasOne(x=>x.Permission).WithMany(d=>d.UserSiteRoll).HasForeignKey(e=>e.PermissionId).HasPrincipalKey(g => g.Id);


            builder.ToTable("UserSiteRoll");
        }
    }
}
