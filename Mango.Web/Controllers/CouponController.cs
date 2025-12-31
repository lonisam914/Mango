using Mango.Web.Models;
using Mango.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace Mango.Web.Controllers
{
	public class CouponController : Controller
	{
		private readonly ICouponService _couponService;
		public CouponController(ICouponService couponService)
		{
			_couponService = couponService;
		}
		public async Task<IActionResult> CouponIndex()
		 {
			List<CouponDto> list = new();
			
			ResponceDto? responce = await _couponService.GetAllCouponAsync();

			if (responce != null && responce.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responce.Result));
			}
			return View(list);
		}

		public async Task<IActionResult> CouponCreate()
		{ 

			return  View();
			
		}
		[HttpPost]
		public async Task<IActionResult> CouponCreate(CouponDto model)
		{
			if (ModelState.IsValid)
			{
				ResponceDto? responce = await _couponService.CreateCouponAsync(model);
				if (responce != null && responce.IsSuccess)
				{
					return RedirectToAction(nameof(CouponIndex));
				}

			}
			return View(model);
		}

		public async Task<IActionResult> CouponDelete(int couponId)
		{

			ResponceDto? responce = await _couponService.GetCouponByIdAsync(couponId);

			if (responce != null && responce.IsSuccess)
			{
				CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responce.Result));
				return View(model);
			}
	
			return NotFound();

		}

		[HttpPost]
		public async Task<IActionResult> CouponDelete(CouponDto couponDto)
		{

			ResponceDto? responce = await _couponService.DeleteCouponAsync(couponDto.CouponId);

			if (responce != null && responce.IsSuccess)
			{
				return RedirectToAction(nameof(CouponIndex));
			}

			return View(couponDto);

		}
	}
}
