using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Repository.Implementation;
using eVenda.Estoque.Service.ServiceException;
using System.Linq;

namespace eVenda.Estoque.Service
{
	class ValidaProduto
	{
		public void ValidaQuantidadeMaiorQueZero(int quantidade)
		{
			if (quantidade < 0)
				throw new QuantidadeAbaixoZeroException();
		}

		public void ValidaValorMaiorQueZero(decimal valor)
		{
			if (valor < 0)
				throw new ValorAbaixoZeroException();
		}

		public void ValidaProdutoExistente(Produto produto)
		{
			ProdutoRepository produtoRepository = new ProdutoRepository();

			var produtos = produtoRepository.ObtemProdutosPorCodigoNome(produto.Codigo, produto.Nome);
			if (produtos != null && produtos.Count() > 0)
				throw new ProdutoExistenteException();
		}
	}
}
