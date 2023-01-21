using System.ComponentModel.DataAnnotations;

namespace EMedicine.Models
{
	public class Orders
	{
		[Key]
		public int Id { get; set; }

		public int UserId { get; set; }
		public Users User { get; set; }

		public string OrderNo { get; set; }
		public decimal OrderTotal { get; set; }
		public string OrderStatus { get; set; }
	}
}
