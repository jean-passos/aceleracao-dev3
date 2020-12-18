using System;
using System.Collections.Generic;
using System.Text;

namespace eVenda.Estoque.Repository.Infra
{
	public interface IRepository<T>
	{
		void Add(T entity);
		void Update(T entity);
		T GetByPk(long id);

	}
}
