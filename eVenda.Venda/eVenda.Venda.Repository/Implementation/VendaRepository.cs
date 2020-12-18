using NSDomainModel = eVenda.Venda.DomainModel.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using eVenda.Venda.Repository.Infra;

namespace eVenda.Venda.Repository.Implementation
{
	public class VendaRepository : RepositoryBase<NSDomainModel.Venda>
	{
		public override void Add(NSDomainModel.Venda entity)
		{
			_vendaContext.Add(entity);
			_vendaContext.Entry(entity.Produto).State = EntityState.Modified;
			_vendaContext.Update(entity.Produto);
			_vendaContext.SaveChanges();
		}

		public NSDomainModel.Produto ObtemProdutoPeloCodigo(string codigo)
		{
			return _vendaContext.Produto.SingleOrDefault(p => p.Codigo.Equals(codigo, StringComparison.CurrentCultureIgnoreCase));
		}

	}
}
