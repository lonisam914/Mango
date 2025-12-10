using Mango.Web.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Services
{
	public class BaseService : IBaseService
	{
		private IHttpClientFactory _httpClientFactory;
		public BaseService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<ResponceDto> SendAsync(RequestDto requestDto)
		{
			try
			{
				HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
				HttpRequestMessage message = new();
				message.Headers.Add("Accept", "application/json");
				//token
				message.RequestUri = new Uri(requestDto.Url);

				if (requestDto.Data != null)
				{
					message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
				}

				HttpResponseMessage? apiResponce = null;

				switch (requestDto.ApiType)
				{
					case ApiType.POST:
						message.Method = HttpMethod.Post;
						break;

					case ApiType.DELETE:
						message.Method = HttpMethod.Delete;
						break;
					case ApiType.PUT:
						message.Method = HttpMethod.Put;
						break;
					default:
						message.Method = HttpMethod.Get;
						break;
				}

				apiResponce = await client.SendAsync(message);

				switch (apiResponce.StatusCode)
				{
					case HttpStatusCode.NotFound:
						return new() { IsSuccess = false, Message = "Not found" };
					case HttpStatusCode.Forbidden:
						return new() { IsSuccess = false, Message = "Access Denied" };
					case HttpStatusCode.Unauthorized:
						return new() { IsSuccess = false, Message = "Unauthorized" };
					case HttpStatusCode.InternalServerError:
						return new() { IsSuccess = false, Message = "Internal Server Error" };
					default:
						var apiContent = await apiResponce.Content.ReadAsStringAsync();
						var apiResponceDto = JsonConvert.DeserializeObject<ResponceDto>(apiContent);
						return apiResponceDto;
				}

			}
			catch (Exception ex)
			{

				var dto = new ResponceDto
				{
					Message = ex.Message.ToString(),
					IsSuccess = false,
				};
				return dto;
					
			}
			

		}

	}        
		
	
}
