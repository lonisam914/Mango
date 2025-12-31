using Mango.Service.AuthAPI.Models.Dto;
using Microsoft.SqlServer.Server;

namespace Mango.Service.AuthAPI.Service.IService
{
	public interface IAuthService
	{
		Task<string> Register(RegistrationRequestDto registrationRequestDto);

		Task<LoginResponceDto> Login(LoginRequesDto loginRequesDto);

		Task<bool> Assign(string email, string roleName);
	}
}
