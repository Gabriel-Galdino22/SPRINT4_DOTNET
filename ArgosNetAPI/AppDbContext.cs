using Microsoft.EntityFrameworkCore;
using ArgosNetAPI.Models;

namespace ArgosNetAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; } // Adiciona o DbSet para Cliente

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração para o nome das tabelas e colunas em caixa alta
            modelBuilder.Entity<Produto>().ToTable("PRODUTOS");
            modelBuilder.Entity<Produto>().Property(p => p.Id).HasColumnName("ID");
            modelBuilder.Entity<Produto>().Property(p => p.Nome).HasColumnName("NOME");
            modelBuilder.Entity<Produto>().Property(p => p.Descricao).HasColumnName("DESCRICAO");
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasColumnName("PRECO");
            modelBuilder.Entity<Produto>().Property(p => p.QuantidadeEmEstoque).HasColumnName("QUANTIDADEEMESTOQUE");

            modelBuilder.Entity<Cliente>().ToTable("CLIENTES"); // Nome da tabela em caixa alta
            modelBuilder.Entity<Cliente>().Property(c => c.Id).HasColumnName("ID");
            modelBuilder.Entity<Cliente>().Property(c => c.Nome).HasColumnName("NOME");
            modelBuilder.Entity<Cliente>().Property(c => c.Email).HasColumnName("EMAIL");
            modelBuilder.Entity<Cliente>().Property(c => c.Telefone).HasColumnName("TELEFONE");
            modelBuilder.Entity<Cliente>().Property(c => c.Endereco).HasColumnName("ENDERECO");
        }
    }
}
