using EMedicine.Data;
using EMedicine.Models;
using EMedicine.Repositories.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMedicine.Repositories
{
	public class UsersRepo : GenericRepository<Users>, IUsersRepo
	{
		private readonly DAL _context;
		public UsersRepo(DAL context) : base(context)
		{
			_context= context;
		}

		public bool LoginAuth(Users user)
		{
			var result = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
			return (result != null);
		}

		public Users UpdateProfile(Users user)
		{
			var result = _context.Users.Update(user);
			return (result != null) ? user : null;
		}
	}
}
