using EMedicine.Models;
using EMedicine.Repositories.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

		[HttpPut]
		[Route("UpdateMedicine")]
		public Response UpdateMedicine(Medicines md)
		{
			var res = _unitOfWork.Medicines.Update(md);
			if (res != null)
			{
				return (new Response { StatusCode = 200, StatusMessage = "Medicine Updated Successfully!", Medicine = res });
			}
			return (new Response { StatusCode = 100, StatusMessage = "Medicine Not Save Try Again!" });
		}

		[HttpGet]
		[Route("listMedicine")]
		public Response listMedicine ()
		{
			var res = _unitOfWork.Medicines.GetAll().ToList();
			if (res != null)
			{
				return (new Response { StatusCode = 200, StatusMessage = "Medicine Fetched Successfully!",ListMedicines = res });
			}
			return (new Response { StatusCode = 100, StatusMessage = "Medicine Not Fetched Try Again!" });
		}

		[HttpGet]
		[Route("viewMedicine/{id}")]
		public Response viewMedicine(int id)
		{
			var res = _unitOfWork.Medicines.GetById(id);
			if (res != null)
			{
				return (new Response { StatusCode = 200, StatusMessage = "Medicine Fetched Successfully!", Medicine = res });
			}
			return (new Response { StatusCode = 100, StatusMessage = "Medicine Not Fetched Try Again!" });
		}
	}
}
