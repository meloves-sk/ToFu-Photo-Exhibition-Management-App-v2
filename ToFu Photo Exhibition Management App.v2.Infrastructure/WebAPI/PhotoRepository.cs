using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Response;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI
{
	public class PhotoRepository : IPhotoRepository
	{
		public async Task<ImmutableList<PhotoEntity>> GetPhotosAsync(int categoryId, int roundId, int manufacturerId, int teamId, int carId)
		{
			var result = await APIHelper.Get<ServiceResponse<IEnumerable<PhotoResponseDto>>>($"api/photo/category/{categoryId}/round/{roundId}/manufacturer/{manufacturerId}/team/{teamId}/car/{carId}");
			Guard.IsNull(result, "写真の取得に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Data
				.Select(a => new PhotoEntity(
					a.Id,
					a.FilePath,
					a.Description,
					a.RoundId,
					a.CarId,
					a.Round,
					a.Category,
					a.Car,
					a.CarNo,
					a.Team,
					a.Manufacturer))
				.ToImmutableList();
		}
	}
}
