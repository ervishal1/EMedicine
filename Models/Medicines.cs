using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMedicine.Models
{
	public class Medicines
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Manifracturer { get; set; }

		public decimal UnitPrice { get; set; }
		public decimal Discount { get; set; }

		public int Quantity { get; set; }
		public DateTime ExpDate { get; set; }

		public string ImageUrl { get; set; }
		public int Status { get; set; }

		[NotMapped]
		public IFormFile ImageUpload { get; set; }
	}
}
