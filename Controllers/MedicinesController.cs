using EMedicine.Models;
using EMedicine.Repositories.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMedicine.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MedicinesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public MedicinesController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpPost]
		[Route("addMedicine")]
		public Response AddMedicine(Medicines md)
		{
			var res = _unitOfWork.Medicines.Add(md);
			if (res)
			{
				return (new Response { StatusCode = 200, StatusMessage = "Medicine Inserted Successfully!" });
			}
			return (new Response { StatusCode = 100, StatusMessage = "Medicine Not Save Try Again!" });
		}

		[HttpPost]
		[Route("UpdateMedicine")]
		public Response UpdateMedicine(Medicines md)
		{
			var res = _unitOfWork.Medicines.Add(md);
			if (res)
			{
				return (new Response { StatusCode = 200, StatusMessage = "Medicine Updated Successfully!" });
			}
			return (new Response { StatusCode = 100, StatusMessage = "Medicine Not Save Try Again!" });
		}
	}
}
