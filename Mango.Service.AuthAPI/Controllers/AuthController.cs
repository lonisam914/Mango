using Mango.Service.AuthAPI.Models.Dto;
using Mango.Service.AuthAPI.Service.IService;
using Mango.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Mango.Service.AuthAPI.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{

		private readonly IAuthService _authService;
		protected ResponceDto _responceDto;

		public AuthController(IAuthService authService)
		{
			_authService=authService;
			_responceDto = new();
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto)
		{
			var errorMessage = await _authService.Register(registrationRequestDto);
			if (!string.IsNullOrEmpty(errorMessage))
			{
				_responceDto.IsSuccess = false;
				_responceDto.Message = errorMessage;
				return BadRequest(_responceDto);
			}

			return Ok(_responceDto); 
		}

		[HttpPost("login")] 
		public async Task<IActionResult> Login(LoginRequesDto requesDto)
		{
			var loginResponce = await _authService.Login(requesDto);
			if (loginResponce.User == null)
			{
				_responceDto.IsSuccess = false;
				_responceDto.Message = "UserName and Password is incorrect";
				return BadRequest(_responceDto);
			}
			_responceDto.Result = loginResponce;
			return Ok(_responceDto);
		}
	}
}
