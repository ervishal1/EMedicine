using EMedicine.Models;

namespace EMedicine.Repositories.Infrastructure
{
	public interface IMedicineRepo : IGenericRepository<Medicines>
	{
		public Medicines Update(Medicines md);
	}
}
