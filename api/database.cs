
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Servico> Servicos { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servico>(entity =>
            {
                // define que o preco base tem no maximo 18 casas inteiras e 2 decimais
                entity.Property(e => e.PrecoBase).HasColumnType("decimal(18, 2)");
                
                // define que a descrição tem tamanho maximo de 255 (ajuda em bancos grandes)
                entity.Property(e => e.Descricao).HasMaxLength(255);       
            });
        }
    
    }
}
