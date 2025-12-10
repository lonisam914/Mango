using Mango.Web.Models;

namespace Mango.Web.Services
{
	public interface IBaseService
	{
		Task<ResponceDto> SendAsync(RequestDto requestDto);
	}
}
