using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Request;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Response;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI
{
	public class CarRepository : ICarRepository
	{
		public async Task<ImmutableList<CarEntity>> GetCarsAsync(Id? categoryId, Id? manufacturerId, Id? teamId)
		{
			if (!Guard.NotAllNull(categoryId, manufacturerId, teamId))
			{
				return ImmutableList<CarEntity>.Empty;
			}
			var result = await APIHelper.Get<ServiceResponse<IEnumerable<CarResponseDto>>>($"api/car/category/{categoryId!.Value}/manufacturer/{manufacturerId!.Value}/team/{teamId!.Value}");
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

		public async Task<ImmutableList<CarEntity>> GetCarsWithDefaultAsync(Id? categoryId, Id? manufacturerId, Id? teamId)
		{
			var cars = await GetCarsAsync(categoryId, manufacturerId, teamId);
			return cars.AddDefaultValue(new CarEntity(0, "ALL", 0, 0, string.Empty, string.Empty, string.Empty));
		}

		public async Task<string> SaveCarAsync(Id? carId, string name, int carNo, Id teamInformationId)
		{
			var request = new CarRequestDto(carId == null ? 0 : carId.Value, name, carNo, teamInformationId.Value);
			var result = carId == null
				? await APIHelper.Post("api/car", request)
				: await APIHelper.Put("api/car", request);
			Guard.IsNull(result, "車両の保存に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Message;
		}

		public async Task<string> DeleteCarAsync(Id carId)
		{
			var result = await APIHelper.Delete($"api/car/{carId.Value}");
			Guard.IsNull(result, "車両の削除に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Message;
		}
	}
}
