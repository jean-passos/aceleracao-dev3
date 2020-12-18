using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Repository.Infra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eVenda.Estoque.Repository.Implementation
{
	public class ProdutoRepository : RepositoryBase<Produto>
	{
		public IEnumerable<Produto> ObtemProdutosPorCodigoNome(string codigo, string nome)
		{
			return _estoqueContext
						.Produto
						.Where(p => p.Codigo.Equals(codigo, StringComparison.CurrentCultureIgnoreCase) || p.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase));
		}

		public Produto ObtemProdutoPorCodigo(string codigo)
		{
			return _estoqueContext.Produto.SingleOrDefault(p => p.Codigo.Equals(codigo, StringComparison.CurrentCultureIgnoreCase));
		}

		public IEnumerable<Produto> ObtemTodosProdutos()
		{
			return _estoqueContext.Produto;
		}
	}
}
