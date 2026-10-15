using GestorOS.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorOS.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // Se não existir cria tudo null.
        public DbSet<Cliente> Clientes { get; set; } = null;
        public DbSet<OrdemServico> OrdensServicos { get; set; } = null;
        public DbSet<CategoriaServicos> CategoriasServicos { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrdemServico>()
                .HasOne(o => o.Cliente)
                .WithMany(c => c.Ordens)
                .HasForeignKey(o => o.ClienteModelId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<OrdemServico>()
                .HasOne(o => o.CategoriaServicos)
                .WithMany(c => c.Ordens)
                .HasForeignKey(o => o.CategoriaServicosModelId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CategoriaServicos>().HasData(
                new CategoriaServicos { Id = 1, Nome = "Manutenção", Descricao = "Serviços de manutenção preventiva e corretiva" },
                new CategoriaServicos { Id = 2, Nome = "Instalação", Descricao = "Instalação de equipamentos e sistemas" },
                new CategoriaServicos { Id = 3, Nome = "Reparo", Descricao = "Reparos e substituições de componentes   " }
            );
                
        }
            
    }
}
