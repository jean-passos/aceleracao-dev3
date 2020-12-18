using System;
using System.Collections.Generic;
using System.Text;

namespace eVenda.Estoque.Repository.Infra
{
	public abstract class RepositoryBase<T> : IRepository<T> where T : class
	{

		protected readonly EstoqueContext _estoqueContext = new EstoqueContext();

		public virtual void Add(T entity)
		{
			_estoqueContext.Add(entity);
			_estoqueContext.SaveChanges();
		}

		public T GetByPk(long id)
		{
			return _estoqueContext.Find<T>(id);
		}

		public virtual void Update(T entity)
		{
			_estoqueContext.Update(entity);
			_estoqueContext.SaveChanges();
		}
	}
}
