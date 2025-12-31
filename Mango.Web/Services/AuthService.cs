using Mango.Web.Models;
using Mango.Web.Services.IService;
using Mango.Web.Utility;

namespace Mango.Web.Services
{
	public class AuthService : IAuthService
	{
		private readonly IBaseService _baseService;

		public AuthService(IBaseService baseService)
		{
			_baseService = baseService;	
		}
		public async Task<ResponceDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = registrationRequestDto,
				Url = SD.AuthAPIBase + "/api/auth/AssignRole"
			});
		}

		public async Task<ResponceDto?> LoginAsync(LoginRequesDto loginRequesDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = loginRequesDto,
				Url = SD.AuthAPIBase + "/api/auth/login"
			});
		}

		public async Task<ResponceDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = registrationRequestDto,
				Url = SD.AuthAPIBase + "/api/auth/register"
			});
		}
	}
}
