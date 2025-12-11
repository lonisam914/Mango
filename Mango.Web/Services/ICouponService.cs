using Mango.Web.Models;

namespace Mango.Web.Services
{
	public interface ICouponService
	{
		Task<ResponceDto?> GetCouponAsync(string couponCOde);
		Task<ResponceDto?> GetAllCouponAsync();
		Task<ResponceDto?> GetCouponByIdAsync(int id);
		Task<ResponceDto?> CreateCouponAsync(CouponDto couponDto);

		Task<ResponceDto?> UpdateCouponAsync(CouponDto couponDto);

		Task<ResponceDto?> DeleteCouponAsync(int id);





	}
}
