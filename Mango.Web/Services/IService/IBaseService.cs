using Mango.Web.Models;

namespace Mango.Web.Services.IService
{
	public interface IBaseService
	{
		Task<ResponceDto> SendAsync(RequestDto requestDto);
	}
}
