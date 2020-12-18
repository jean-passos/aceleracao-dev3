using eVenda.Venda.DomainModel.Model;
using eVenda.Venda.Repository.Infra;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace eVenda.Venda.Repository.Implementation
{
	public class ProdutoRepository : RepositoryBase<Produto>
	{
		public IEnumerable<Produto> ObterComQuantidadeMaiorZero()
		{
			return _vendaContext.Produto.Where(p => p.Quantidade > 0);
		}

		public Produto ObtemProdutoPeloCodigo(string codigo)
		{
			return _vendaContext.Produto.SingleOrDefault(p => p.Codigo.Equals(codigo, StringComparison.CurrentCultureIgnoreCase));
		}



	}
}
