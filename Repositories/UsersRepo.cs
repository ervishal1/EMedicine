using EMedicine.Data;
using EMedicine.Models;
using EMedicine.Repositories.Infrastructure;
using System.Collections.Generic;

namespace EMedicine.Repositories
{
	public class UsersRepo : GenericRepository<Users>, IUsersRepo
	{
		public UsersRepo(DAL context) : base(context)
		{
		}
	}
}
