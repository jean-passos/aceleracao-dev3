using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSDomainModel = eVenda.Venda.DomainModel.Model;


namespace eVenda.Venda.Repository.Configuration
{
	internal class VendaEntityConfiguration : IEntityTypeConfiguration<NSDomainModel.Venda>
	{
		public void Configure(EntityTypeBuilder<NSDomainModel.Venda> builder)
		{
			builder
				.HasKey("Id")
				.HasName("PK_VENDA");
			builder
				.Property(v => v.Id)
				.IsRequired()
				.HasColumnType("bigint")
				.UseSqlServerIdentityColumn();

			builder
				.Property(v => v.QuantidadeVendida)
				.IsRequired()
				.HasColumnType("int");

			builder
				.Property(v => v.ValorVenda)
				.IsRequired()
				.HasColumnType("decimal");
		}
	}
}
