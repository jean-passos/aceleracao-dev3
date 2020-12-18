using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Repository.Implementation;
using eVenda.Estoque.Service.Helper;
using eVenda.Estoque.Service.ServiceException;
using System.Collections.Generic;
using System.Linq;

namespace eVenda.Estoque.Service
{
	public class GerenciaProduto
	{
		private readonly ProdutoRepository produtoRepository = new ProdutoRepository();

		public void IncluiProduto(Produto produtoInclusao)
		{
			ValidaPropriedadesProduto(produtoInclusao);
			VerificaProdutoExiste(produtoInclusao);

			produtoRepository.Add(produtoInclusao);
			produtoInclusao.Id = 0;

			new ServiceBusHelper<Produto>().EnviaMensagem(produtoInclusao, "produtocriado");
		}

		public void AlteraProduto(Produto produtoAtualizado)
		{
			ValidaPropriedadesProduto(produtoAtualizado);
			produtoRepository.Update(produtoAtualizado);
			new ServiceBusHelper<Produto>().EnviaMensagem(produtoAtualizado, "produtoatualizado");
		}

		public IEnumerable<Produto> ObtemTodosProdutos()
		{
			return produtoRepository.ObtemTodosProdutos();
		}

		public void AtualizaProdutoVendido(Produto produtoVendido)
		{
			var produto = produtoRepository.ObtemProdutoPorCodigo(produtoVendido.Codigo);
			produto.Quantidade = produtoVendido.Quantidade;
			produtoRepository.Update(produto);
		}

		private void ValidaPropriedadesProduto(Produto produto)
		{
			ValidaProduto validaProduto = new ValidaProduto();
			validaProduto.ValidaValorMaiorQueZero(produto.Valor);
			validaProduto.ValidaQuantidadeMaiorQueZero(produto.Quantidade);
		}

		private void VerificaProdutoExiste(Produto produto)
		{
			var produtoVerifica = produtoRepository.ObtemProdutosPorCodigoNome(produto.Codigo, produto.Nome);
			if (produtoVerifica != null && produtoVerifica.Count() > 0)
				throw new ProdutoExistenteException();
		}
	}
}
