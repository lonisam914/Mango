using AutoMapper;
using Azure;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CouponAPIController : ControllerBase
	{
		private readonly AppDbContext _db;
		private IMapper _mapper; 
		private ResponceDto _responceDto;
		public CouponAPIController(AppDbContext db, IMapper mapper)
		{
			_db= db;
			_responceDto = new ResponceDto();
			_mapper= mapper;
		}

		[HttpGet]
		public ResponceDto Get()
		{
			try
			{
				IEnumerable<Coupon> objList = _db.Coupons.ToList();
				_responceDto.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
			}
			catch (Exception ex) 
			{
				
			}
			return _responceDto;
		}
		 
		[HttpGet]
		[Route("{id:int}")]
		public ResponceDto Get(int id)
		{
			try
			{
				Coupon obj = _db.Coupons.First(u => u.CouponId == id);
				_responceDto.Result= _mapper.Map<CouponDto>(obj);    //it will converts coupon(obj) into couponDto object
			}
			catch (Exception)
			{
				_responceDto.IsSuccess = false;
				_responceDto.Message = "No items are available"; 
			}
			return _responceDto;
		}


		[HttpGet]
		[Route("GetByCode/{code}")]
		public ResponceDto GetByCode(string code)
		{
			try
			{
				Coupon obj = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower() == code.ToLower());
				if (obj == null)
				{
					_responceDto.IsSuccess = false;
					_responceDto.Message = "No items are available";
				}
				_responceDto.Result = _mapper.Map<CouponDto>(obj);

			}
			catch (Exception ex)
			{
				_responceDto.IsSuccess = false;
				_responceDto.Message = ex.Message;
			}
			return _responceDto;
		}

		[HttpPost]
		public ResponceDto Post([FromBody] CouponDto couponDto)
		{
			try
			{
				Coupon obj = _mapper.Map<Coupon>(couponDto);
				_db.Coupons.Add(obj);
				_db.SaveChanges();
				_responceDto.Result = _mapper.Map<CouponDto>(obj);
			} 
			catch (Exception ex ) 
			{
				_responceDto.IsSuccess = false;
				_responceDto.Message = ex.Message;
			}
			return _responceDto;
		}


		[HttpPut]
		public ResponceDto Put([FromBody] CouponDto couponDto)
		{
			try
			{
				Coupon obj = _mapper.Map<Coupon>(couponDto);
				_db.Coupons.Update(obj);
				_db.SaveChanges();
				_responceDto.Result = _mapper.Map<CouponDto>(obj);
			}
			catch (Exception ex)
			{
				_responceDto.IsSuccess = false;
				_responceDto.Message = ex.Message;
			}
			return _responceDto;
		}

		[HttpDelete]
		public ResponceDto Delete(int id)
		{
			try
			{
				Coupon obj = _db.Coupons.First(u=>u.CouponId == id);
				_db.Coupons.Remove(obj);
				_db.SaveChanges();
			}
			catch (Exception ex)
			{
				_responceDto.IsSuccess = false;
				_responceDto.Message = ex.Message;
			}
			return _responceDto;
		}

	}
}
