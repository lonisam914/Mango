using Mango.Web.Models;
using Mango.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			LoginRequesDto loginRequesDto = new();
			return View(loginRequesDto);
		}

		[HttpGet]
		public IActionResult Register()
		{
			RegistrationRequestDto registrationRequestDto = new();
			return View(registrationRequestDto);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginRequesDto loginRequesDto)
		{
			return View();
		}
	}
}
