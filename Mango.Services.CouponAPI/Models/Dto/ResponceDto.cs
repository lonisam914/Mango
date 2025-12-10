using System.Globalization;

namespace Mango.Services.CouponAPI.Models
{
	public class ResponceDto
	{
		public object? Result { get; set; }
		public bool IsSuccess { get; set; } =true;
		public String Message { get; set; } = "";
	}
}
 