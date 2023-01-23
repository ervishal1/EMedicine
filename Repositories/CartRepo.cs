using EMedicine.Data;
using EMedicine.Models;
using EMedicine.Repositories.Infrastructure;

namespace EMedicine.Repositories
{
	public class CartRepo : GenericRepository<Cart>, ICartRepo
	{
		public CartRepo(DAL context) : base(context)
		{
		}
	}
}
