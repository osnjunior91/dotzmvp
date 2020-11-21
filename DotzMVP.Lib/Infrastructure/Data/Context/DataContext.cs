using DotzMVP.Lib.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DotzMVP.Lib.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Address> Adresses { get; set; }
        public DbSet<ChangeRegister> ChangeRegisters { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
