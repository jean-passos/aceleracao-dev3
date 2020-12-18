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
			return produtoRepository.ObterComQuantidadeMaiorZero();
		}

		public void IncluiProduto(Produto produto)
		{
			produtoRepository.Add(produto);
		}

		public void AlteraProduto(Produto produtoAlterado)
		{
			Produto produto = produtoRepository.ObtemProdutoPeloCodigo(produtoAlterado.Codigo);
			produto.Valor = produtoAlterado.Valor;
			produto.Quantidade = produtoAlterado.Quantidade;
			produtoRepository.Update(produto);
		}
	}
}
