namespace eVenda.Venda.DomainModel.Model
{
	public class Venda
	{
		public long Id { get; set; }
		public int QuantidadeVendida { get; set; }
		public decimal ValorVenda { get; set; }
		public Produto Produto { get; set; }
	}
}
