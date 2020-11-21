using DotzMVP.Lib.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotzMVP.Lib.Infrastructure.Data.Configuration
{
    public class ChangeRegisterConfiguration : IEntityTypeConfiguration<ChangeRegister>
    {
        public void Configure(EntityTypeBuilder<ChangeRegister> builder)
        {
            builder.ToTable("ChangeRegister");

            builder.HasOne(x => x.Person)
                .WithMany()
                .HasForeignKey(x => x.PersonID);

            builder.HasMany(x => x.Itens);
        }
    }
}
