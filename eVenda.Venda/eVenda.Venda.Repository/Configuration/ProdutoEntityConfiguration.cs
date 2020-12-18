using eVenda.Venda.DomainModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eVenda.Venda.Repository.Configuration
{
	internal class ProdutoEntityConfiguration : IEntityTypeConfiguration<Produto>
	{
		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder
				.HasKey("Id")
				.HasName("PK_PRODUTO");
			builder
				.Property(p => p.Id)
				.IsRequired()
				.HasColumnType("bigint")
				.UseSqlServerIdentityColumn();

			builder
				.Property(p => p.Codigo)
				.IsRequired()
				.HasColumnType("varchar(50)");

			builder
				.Property(p => p.Nome)
				.IsRequired()
				.HasColumnType("varchar(200)");

			builder
				.Property(p => p.Valor)
				.IsRequired()
				.HasColumnType("decimal");

			builder
				.Property(p => p.Quantidade)
				.IsRequired()
				.HasColumnType("int");
		}
	}
}
