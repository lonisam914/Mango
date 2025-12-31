using Mango.Web.Models;
using Mango.Web.Services.IService;
using Mango.Web.Utility;

namespace Mango.Web.Services
{
	public class CouponService : ICouponService
	{
		private readonly IBaseService _baseService;
		public CouponService(IBaseService baseService)
		{
			_baseService = baseService;
		}
		public async Task<ResponceDto?> CreateCouponAsync(CouponDto couponDto)
		 {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = couponDto,
				Url = SD.CouponAPIBase + "/api/couponAPI/"
			});
		}

		public async Task<ResponceDto?> DeleteCouponAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.CouponAPIBase + "/api/couponAPI/" + id
			}); 
		}

		public async Task<ResponceDto?> GetAllCouponAsync()
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/couponAPI" 
			});
 		}

		public async Task<ResponceDto?> GetCouponAsync(string couponCOde)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/couponAPI/GetByCode/" + couponCOde
			});
		}

		public async Task<ResponceDto?> GetCouponByIdAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/couponAPI/" + id
			});
		}

		public async  Task<ResponceDto?> UpdateCouponAsync(CouponDto couponDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.PUT,
				Data = couponDto,
				Url = SD.CouponAPIBase + "/api/couponAPI/"
			});
		}
	}
}
