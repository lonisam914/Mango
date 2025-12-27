using System.Globalization;

namespace Mango.Services.AuthAPI.Models
{
	public class ResponceDto
	{
		public object? Result { get; set; }
		public bool IsSuccess { get; set; } =true;
		public String Message { get; set; } = "";
	}
}
 