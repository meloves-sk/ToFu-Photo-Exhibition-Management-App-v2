using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Response;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI
{
	public class CarRepository : ICarRepository
	{
		public async Task<ImmutableList<CarEntity>> GetCarsAsync(int? categoryId, int? manufacturerId, int? teamId)
		{
			if (!Guard.NotAllNull(categoryId, manufacturerId, teamId))
			{
				return ImmutableList<CarEntity>.Empty;
			}
			var result = await APIHelper.Get<ServiceResponse<IEnumerable<CarResponseDto>>>($"api/car/category/{categoryId}/manufacturer/{manufacturerId}/team/{teamId}");
			Guard.IsNull(result, "車両の取得に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Data
				.Select(a => new CarEntity(
					a.Id,
					a.Name,
					a.CarNo,
					a.TeamInformationId,
					a.Team,
					a.Manufacturer,
					a.Category))
				.ToImmutableList();
		}

		public async Task<ImmutableList<CarEntity>> GetCarsWithDefaultAsync(int? categoryId, int? manufacturerId, int? teamId)
		{
			var cars = await GetCarsAsync(categoryId, manufacturerId, teamId);
			return cars.AddDefaultValue(new CarEntity(0, "ALL", 0, 0, string.Empty, string.Empty, string.Empty));
		}
	}
}
