using DotzMVP.Lib.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotzMVP.Lib.Infrastructure.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasOne(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressID);

            builder.HasDiscriminator<string>("EntityType")
                .HasValue<User>("User")
                .HasValue<UserAdmin>("UserAdmin");
        }
    }
}
