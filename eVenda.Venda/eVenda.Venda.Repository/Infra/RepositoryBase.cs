using System;
using System.Collections.Generic;
using System.Text;

namespace eVenda.Venda.Repository.Infra
{
	public abstract class RepositoryBase<T> : IRepository<T> where T : class
	{
		protected readonly VendaContext _vendaContext = new VendaContext();

		public virtual void Add(T entity)
		{
			_vendaContext.Add(entity);
			_vendaContext.SaveChanges();
		}

		public virtual void Update(T entity)
		{
			_vendaContext.Update(entity);
			_vendaContext.SaveChanges();
		}
	}
}
