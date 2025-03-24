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
	public class ManufacturerRepository : IManufacturerRepository
	{
		public async Task<ImmutableList<ManufacturerEntity>> GetManufacturersAsync(Id? categoryId)
		{
			if (!Guard.NotAllNull(categoryId))
			{
				return ImmutableList<ManufacturerEntity>.Empty;
			}
			var result = await APIHelper.Get<ServiceResponse<IEnumerable<ManufacturerResponseDto>>>($"api/manufacturer/category/{categoryId!.Value}");
			Guard.IsNull(result, "メーカーの取得に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Data
				.Select(a => new ManufacturerEntity(
					a.Id,
					a.Name))
				.ToImmutableList();
		}

		public async Task<ImmutableList<ManufacturerEntity>> GetManufacturersWithDefaultAsync(Id? categoryId)
		{
			var manufacturers = await GetManufacturersAsync(categoryId);
			return manufacturers.AddDefaultValue(new ManufacturerEntity(0, "ALL"));
		}

		public async Task<string> SaveManufacturerAsync(Id? manufacturerId, string name)
		{
			var request = new ManufacturerRequestDto(manufacturerId == null ? 0 : manufacturerId.Value, name);
			var result = manufacturerId == null
				? await APIHelper.Post("api/manufacturer", request)
				: await APIHelper.Put("api/manufacturer", request);
			Guard.IsNull(result, "メーカーの保存に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Message;
		}

		public async Task<string> DeleteManufacturerAsync(Id manufacturerId)
		{
			var result = await APIHelper.Delete($"api/manufacturer/{manufacturerId.Value}");
			Guard.IsNull(result, "メーカーの削除に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Message;
		}
	}
}
