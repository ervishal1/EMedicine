using EMedicine.Models;
using EMedicine.Repositories.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EMedicine.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public AdminController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		[Route("usersList")]
		public Response UsersList()
		{
			var res = _unitOfWork.Users.GetAll().ToList();
			if (res != null)
			{
				return (new Response { StatusCode = 200, StatusMessage = "Users details Fetched!", ListUsers = res });
			}
			return (new Response { StatusCode = 100, StatusMessage = "Users Details Are Not Avilable!" });
		}
			
	}
}
