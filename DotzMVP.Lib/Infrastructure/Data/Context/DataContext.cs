using DotzMVP.Lib.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotzMVP.Lib.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Address> Adresses { get; set; }
        public DbSet<ChangeRegister> ChangeRegisters { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdmin> UsersAdmin { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == false);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            DateTime saveTime = DateTime.Now;
            foreach (var entry in this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Property("CreatedAt")?.CurrentValue == null)
                {
                    entry.Property("CreatedAt").CurrentValue = saveTime;
                    entry.Property("ModifiedAt").CurrentValue = saveTime;
                }
                else
                {
                    entry.Property("ModifiedAt").CurrentValue = saveTime;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
