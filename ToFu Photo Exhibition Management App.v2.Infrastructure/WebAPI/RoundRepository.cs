using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Response;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI
{
	public class RoundRepository : IRoundRepository
	{
		public async Task<ImmutableList<RoundEntity>> GetRoundsAsync(int? categoryId)
		{
			if (!Guard.NotAllNull(categoryId))
			{
				return ImmutableList<RoundEntity>.Empty;
			}
			var result = await APIHelper.Get<ServiceResponse<IEnumerable<RoundResponseDto>>>($"api/round/category/{categoryId}");
			Guard.IsNull(result, "ラウンドの取得に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Data
				.Select(a => new RoundEntity(
					a.Id,
					a.Name))
				.ToImmutableList();
		}

		public async Task<ImmutableList<RoundEntity>> GetRoundsWithDefaultAsync(int? categoryId)
		{
			var rounds = await GetRoundsAsync(categoryId);
			return rounds.AddDefaultValue(new RoundEntity(0, "ALL"));
		}
	}
}
