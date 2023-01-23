using EMedicine.Models;
using System.Collections.Generic;

namespace EMedicine.Repositories.Infrastructure
{
	public interface IUsersRepo :IGenericRepository<Users>
	{
		public bool LoginAuth(Users user);
		public Users UpdateProfile(Users user);
	}
}
