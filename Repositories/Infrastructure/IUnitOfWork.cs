namespace EMedicine.Repositories.Infrastructure
{
	public interface IUnitOfWork
	{
		IUsersRepo Users { get; }
		void save();
	}
}
