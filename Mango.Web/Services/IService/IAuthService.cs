using Mango.Web.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace Mango.Web.Services.IService
{
	public interface IAuthService
	{
		Task<ResponceDto?> LoginAsync(LoginRequesDto loginRequesDto);
		Task<ResponceDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
		Task<ResponceDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);

	}
}
