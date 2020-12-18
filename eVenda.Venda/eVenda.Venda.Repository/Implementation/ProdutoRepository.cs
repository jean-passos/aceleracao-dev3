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

	}
}
