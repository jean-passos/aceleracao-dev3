using NSDomainModel = eVenda.Venda.DomainModel.Model;
using eVenda.Venda.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace eVenda.Venda.Repository
{
	public class VendaContext : DbContext
	{
		public DbSet<NSDomainModel.Produto> Produto { get; set; }
		public DbSet<NSDomainModel.Venda> Venda { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=VendaDb;Trusted_Connection=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProdutoEntityConfiguration());
			modelBuilder.ApplyConfiguration(new VendaEntityConfiguration());
		}
	}
}
