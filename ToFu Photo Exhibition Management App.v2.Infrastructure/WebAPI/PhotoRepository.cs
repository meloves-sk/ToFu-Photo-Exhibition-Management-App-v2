using System.Collections.Immutable;
using System.IO;
using System.Net;
using System.Net.Http;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Request;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Response;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI
{
	public class PhotoRepository : IPhotoRepository
	{
		public async Task<ImmutableList<PhotoEntity>> GetPhotosAsync(Id? categoryId, Id? roundId, Id? manufacturerId, Id? teamId, Id? carId)
		{
			if (!Guard.NotAllNull(categoryId, roundId, manufacturerId, teamId, carId))
			{
				return ImmutableList<PhotoEntity>.Empty;
			}
			var result = await APIHelper.Get<ServiceResponse<IEnumerable<PhotoResponseDto>>>($"api/photo/category/{categoryId!.Value}/round/{roundId!.Value}/manufacturer/{manufacturerId!.Value}/team/{teamId!.Value}/car/{carId!.Value}");
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
		public async Task<string> SavePhotoAsync(Id? photoId, string description, Id roundId, Id carId, string filePath)
		{
			using (HttpClient httpClient = new HttpClient())
			{
				var image = photoId == null
					? File.ReadAllBytes(filePath)
					: await httpClient.GetByteArrayAsync(filePath);
				var request = new PhotoRequestDto(photoId == null ? 0 : photoId.Value, description, roundId.Value, carId.Value, image);
				var result = photoId == null
					? await APIHelper.Post("api/photo", request)
					: await APIHelper.Put("api/photo", request);
				Guard.IsNull(result, "写真の保存に失敗しました");
				Guard.IsFail(result.Success, result.Message);
				return result.Message;
			}
		}
		public async Task<string> DeletePhotoAsync(Id photoId)
		{
			var result = await APIHelper.Delete($"api/photo/{photoId.Value}");
			Guard.IsNull(result, "写真の削除に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Message;
		}

	}
}
