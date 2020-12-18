using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace eVenda.Estoque.Repository
{
	public class EstoqueContext : DbContext
	{
		public DbSet<Produto> Produto { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EstoqueDb;Trusted_Connection=True");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProdutoTypeConfiguration());
		}
	}
}
