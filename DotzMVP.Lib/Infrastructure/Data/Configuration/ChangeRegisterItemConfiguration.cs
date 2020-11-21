using DotzMVP.Lib.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotzMVP.Lib.Infrastructure.Data.Configuration
{
    public class ChangeRegisterItemConfiguration : IEntityTypeConfiguration<ChangeRegisterItem>
    {
        public void Configure(EntityTypeBuilder<ChangeRegisterItem> builder)
        {
            builder.ToTable("ChangeRegisterItem");

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductID);
        }
    }
}
