using EMedicine.Data;
using EMedicine.Models;
using EMedicine.Repositories.Infrastructure;

namespace EMedicine.Repositories
{
	public class OrdersRepo : GenericRepository<Orders>, IOrdersRepo
	{
		public OrdersRepo(DAL context) : base(context)
		{
		}
	}
}
