using eVenda.Venda.DomainModel.Model;
using eVenda.Venda.Repository.Implementation;
using System.Collections.Generic;

namespace eVenda.Venda.Service
{
	public class GerenciaProduto
	{

		private readonly ProdutoRepository produtoRepository = new ProdutoRepository();

		public IEnumerable<Produto> ObtemProdutosQuantidadeMaiorQueZero()
		{


			



			return new List<Produto>
			{
				new Produto    { Id = 1, Codigo = "123", Nome = "Nome 01", Quantidade = 100, Valor = 10m},
				new Produto    { Id = 2, Codigo = "456", Nome = "Nome 02", Quantidade = 55, Valor = 12.17m}
			};
		}
	}
}
