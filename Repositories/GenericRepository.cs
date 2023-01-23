using EMedicine.Data;
using EMedicine.Repositories.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EMedicine.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{

		protected readonly DAL _context;

		private DbSet<T> _dbSet;

		public GenericRepository(DAL context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public bool Add(T entity)
		{
			var res =  _dbSet.Add(entity);
			return (res != null);
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
		{
			return _dbSet.Where(expression);
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet;
		}

		public T GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public void Remove(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entitys)
		{
			_dbSet.RemoveRange(entitys);
		}

	}
}
