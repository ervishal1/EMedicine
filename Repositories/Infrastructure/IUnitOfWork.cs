namespace EMedicine.Repositories.Infrastructure
{
	public interface IUnitOfWork
	{
		public IUsersRepo Users { get; }
		public ICartRepo Cart { get; }
		public IOrdersRepo Orders { get; }
		public IMedicineRepo Medicines { get; }

		public void save();

	}
}
