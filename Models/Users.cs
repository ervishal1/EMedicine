using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMedicine.Models
{
	public class Users
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[Required,EmailAddress]
		public string Email { get; set; }
		[Required,PasswordPropertyText]
		public string Password { get; set; }
		public decimal Fund { get; set; }
		public string Type { get; set; }
		public int Status { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
