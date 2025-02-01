using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using ToFuPhotoExhibitionManagementApp.v2.Domain;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Response;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper
{
	public static class APIHelper
	{
		public static async Task<T> Get<T>(string arg)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.Timeout = TimeSpan.FromMinutes(1);
				return await httpClient.GetFromJsonAsync<T>(Path.Combine(Shared.URL, arg));
			}
		}

		public static async Task<ServiceResponse<bool>> Post<T>(string arg, T request)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.Timeout = TimeSpan.FromMinutes(1);
				var result = await httpClient.PostAsJsonAsync(Path.Combine(Shared.URL, arg), request);
				return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
			}
		}

		public static async Task<ServiceResponse<bool>> Put<T>(string arg, T request)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.Timeout = TimeSpan.FromMinutes(1);
				var result = await httpClient.PutAsJsonAsync(Path.Combine(Shared.URL, arg), request);
				return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
			}
		}
		public static async Task<ServiceResponse<bool>> Delete(string arg)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.Timeout = TimeSpan.FromMinutes(1);
				var result = await httpClient.DeleteAsync(Path.Combine(Shared.URL, arg));
				return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
			}
		}
	}
}
