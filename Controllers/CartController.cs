using EMedicine.Models;
using EMedicine.Repositories.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EMedicine.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public CartController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpPost]
		[Route("addToCart")]
		public Response AddToCart(Cart cart)
		{
			var res = _unitOfWork.Cart.Add(cart);
			_unitOfWork.save();

			if (res)
			{
				return (new Response { StatusCode = 200, StatusMessage = "Item Added Successfully!" });
			}

			return (new Response { StatusCode = 100, StatusMessage = "Iteam Add Faild!" });
		}

		[HttpPost]
		[Route("placeOrder")]
		public Response PlaceOrder(Users user)
		{
			var res = _unitOfWork.Orders.Add(new Orders
			{
				UserId = user.Id,
			});
			_unitOfWork.save();

			if (res)
			{
				return (new Response { StatusCode = 200, StatusMessage = "Order Has Been Placed Successfully!" });
			}

			return (new Response { StatusCode = 100, StatusMessage = "Order Could not be placed!" });
		}

		[HttpPost]
		[Route("ordreList")]
		public Response OrderList(Users user)
		{
			var res = _unitOfWork.Orders.GetAll().ToList();
			if (res != null)
			{
				return (new Response { StatusCode = 200, StatusMessage = "Order details Fetched!",ListOrders = res });
			}
			return (new Response { StatusCode = 100, StatusMessage = "Order Details Are Not Avilable!" });
		}
	}
}
