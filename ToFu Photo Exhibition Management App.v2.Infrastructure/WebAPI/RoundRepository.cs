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
	public class RoundRepository : IRoundRepository
	{
		public async Task<ImmutableList<RoundEntity>> GetRoundsAsync(Id? categoryId)
		{
			if (!Guard.NotAllNull(categoryId))
			{
				return ImmutableList<RoundEntity>.Empty;
			}
			var result = await APIHelper.Get<ServiceResponse<IEnumerable<RoundResponseDto>>>($"api/round/category/{categoryId!.Value}");
			Guard.IsNull(result, "ラウンドの取得に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Data
				.Select(a => new RoundEntity(
					a.Id,
					a.Name))
				.ToImmutableList();
		}

		public async Task<ImmutableList<RoundEntity>> GetRoundsWithDefaultAsync(Id? categoryId)
		{
			var rounds = await GetRoundsAsync(categoryId);
			return rounds.AddDefaultValue(new RoundEntity(0, "ALL"));
		}

		public async Task<string> SaveRoundAsync(Id? roundId, string name, Id categoryId)
		{
			var request = new RoundRequestDto(roundId == null ? 0 : roundId.Value, name, categoryId.Value);
			var result =  roundId == null
				? await APIHelper.Post("api/round", request)
				: await APIHelper.Put("api/round", request);
			Guard.IsNull(result, "ラウンドの保存に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Message;
		}

		public async Task<string> DeleteRoundAsync(Id roundId)
		{
			var result = await APIHelper.Delete($"api/round/{roundId.Value}");
			Guard.IsNull(result, "ラウンドの削除に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Message;
		}
	}
}
