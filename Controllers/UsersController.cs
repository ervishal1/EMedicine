using EMedicine.Models;
using EMedicine.Repositories.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EMedicine.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public UsersController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpPost]
		[Route("registration")]

		public Response register(Users users)
		{
			var res = _unitOfWork.Users.Add(users);
			_unitOfWork.save();

			if (res)
			{
				return (new Response { StatusCode = 200, StatusMessage = "User Registered Successfully!" });
			}

			return (new Response { StatusCode = 100, StatusMessage = "User Registration Faild!" });
		}

		[HttpPost]
		[Route("login")]
		public Response login(Users user)
		{
			var data = _unitOfWork.Users.LoginAuth(user);
			if (data)
			{
				return (new Response { StatusCode = 200, StatusMessage = "User Is Valid" });
			}
			return (new Response { StatusCode = 100, StatusMessage = "User Is Faild!" });
		}

		[HttpGet]
		[Route("viewUser/{id}")]
		public Response ViewUser(int id)
		{
			var res = _unitOfWork.Users.GetById(id);
			if (res == null)
			{
				return (new Response { StatusCode = 100, StatusMessage = "User Not Found!" }); ;
			}
			return (new Response { StatusCode = 200, StatusMessage = "User Is Found", User = res });
		}

		[HttpPut]
		[Route("updateProfile")]
		public Response UpdateProfile(Users users)
		{
			var res = _unitOfWork.Users.UpdateProfile(users);
			_unitOfWork.save();

			if (res != null)
			{
				return (new Response { StatusCode = 200, StatusMessage = "Profile Updated Successfully!", User = res });
			}

			return (new Response { StatusCode = 100, StatusMessage = "Profile Update Faild!" });
		}

		[HttpGet]
		[Route("test")]
		public IActionResult test()
		{
			return Ok("Tested Ok");
		}
	}
}
