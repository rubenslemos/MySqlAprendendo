using Microsoft.EntityFrameworkCore;

namespace MySqlAprendendo.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { 
            
        }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                    .HasMaxLength(80);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                    .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .HasData(
                    new Produto { Id = 1, Nome = "Livro C#", Preco = 205.50M, Estoque = 30},
                    new Produto { Id = 2, Nome = "Livro JavaScript", Preco = 105.50M, Estoque = 25},
                    new Produto { Id = 3, Nome = "Livro React", Preco = 75.50M, Estoque = 40}
                );
        }
    }
}
