using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Repository.Infra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eVenda.Estoque.Repository.Implementation
{
	public class ProdutoRepository : IRepository<Produto>
	{

		private readonly EstoqueContext _estoqueContext = new EstoqueContext();


		public void Add(Produto entity)
		{
			_estoqueContext.Add(entity);
			_estoqueContext.SaveChanges();
		}

		public Produto GetByPk(long id)
		{
			return _estoqueContext.Produto.SingleOrDefault(p => p.Id == id);
		}


		public IEnumerable<Produto> ObtemProdutosPorCodigoNome(string codigo, string nome)
		{
			return _estoqueContext
						.Produto
						.Where(p => p.Codigo.Equals(codigo, StringComparison.CurrentCultureIgnoreCase) || p.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase));
		}


		public void Update(Produto entity)
		{
			_estoqueContext.Update(entity);
			_estoqueContext.SaveChanges();
		}

		public IEnumerable<Produto> ObtemTodosProdutos()
		{
			return _estoqueContext.Produto;
		}

	}
}
