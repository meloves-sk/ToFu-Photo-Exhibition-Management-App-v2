using Microsoft.Extensions.Configuration;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain
{
	public static class Shared
	{
		private static readonly IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
		public static readonly string URL = _configuration.GetSection("ApiUrl").Value;
		public static bool IsDammy = _configuration.GetSection("RunMode").Value == "1";
	}
}
