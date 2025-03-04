using AuthenticationAuthorization.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAuthorization.Infrastrucnure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.UserClaims)
                .WithOne(c => c.User)
                .HasForeignKey<UserClaims>(c => c.Id);
        }
    }
}
