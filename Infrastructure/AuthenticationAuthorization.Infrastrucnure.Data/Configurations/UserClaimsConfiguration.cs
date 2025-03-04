using AuthenticationAuthorization.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthenticationAuthorization.Infrastrucnure.Data.Configurations
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<UserClaims>
    {
        public void Configure(EntityTypeBuilder<UserClaims> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.User)
                .WithOne(c => c.UserClaims)
                .HasForeignKey<User>(c => c.UserClaimsId);
        }
    }
}
