﻿using System.ComponentModel.DataAnnotations;

namespace EMedicine.Models
{
	public class Cart
	{
		[Key]
		public int Id { get; set; }

		public int UserId { get; set; }
		public Users User{ get; set; }

		public int MedicineId { get; set; }
		public Medicines Medicine { get; set; }

		public decimal UnitPrice { get; set; }
		public decimal Discount { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
