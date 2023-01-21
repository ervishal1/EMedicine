using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EMedicine.Repositories.Infrastructure
{
	public interface IGenericRepository<T> where T : class
	{
		T GetById(int id);
		IEnumerable<T> GetAll();
		IEnumerable<T> Find(Expression<Func<T,bool>> expression);
		bool Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entitys);
	}
}
