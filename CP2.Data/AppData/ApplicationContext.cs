using CP2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<FornecedorEntity> Fornecedor { get; set; }
        public DbSet<VendedorEntity> Vendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VendedorEntity>()
                .Property(v => v.ComissaoPercentual)
                .HasPrecision(18, 2);

            modelBuilder.Entity<VendedorEntity>()
                .Property(v => v.MetaMensal)
                .HasPrecision(18, 2);


        }
    }
}
