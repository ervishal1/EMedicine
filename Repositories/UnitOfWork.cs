using EMedicine.Data;
using EMedicine.Repositories.Infrastructure;

namespace EMedicine.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DAL _context;

		public UnitOfWork(DAL context)
		{
			_context = context;
			Users = new UsersRepo(_context);
		}
		
		public IUsersRepo Users { get; private set; }

		public void save()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
