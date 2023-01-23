using EMedicine.Data;
using EMedicine.Models;
using EMedicine.Repositories.Infrastructure;

namespace EMedicine.Repositories
{
    public class MedicineRepo : GenericRepository<Medicines>,IMedicineRepo
    {
		private readonly DAL _context;
		public MedicineRepo(DAL context) : base(context)
		{
			_context = context;
		}

		public Medicines Update(Medicines md)
		{
			var result = _context.Medicines.Update(md);
			return (result != null) ? md : null;
		}
	}
}
