namespace eVenda.Venda.Models
{
	public class VendaModel
	{
		public int QuantidadeVendida { get; set; }
		public decimal ValorVenda { get; set; }
		public ProdutoModel Produto { get; set; }
	}
}
