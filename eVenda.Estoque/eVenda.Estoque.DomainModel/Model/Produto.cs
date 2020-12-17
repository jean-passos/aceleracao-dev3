namespace eVenda.Estoque.DomainModel.Model
{
	public class Produto
	{
		public long Id { get; set; }
		public string Codigo { get; set; }
		public string Nome { get; set; }
		public decimal Valor { get; set; }
		public int Quantidade { get; set; }
	}
}
