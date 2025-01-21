using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Response;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI
{
	internal class TeamRepository : ITeamRepository
	{
		public async Task<ImmutableList<TeamEntity>> GetTeamsAsync(int categoryId, int manufacturerId)
		{
			var result = await APIHelper.Get<ServiceResponse<IEnumerable<TeamResponseDto>>>($"api/team/category/{categoryId}/manufacturer/{manufacturerId}");
			Guard.IsNull(result, "チームの取得に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Data
				.Select(a => new TeamEntity(
					a.Id,
					a.Name))
				.ToImmutableList();
		}

		public async Task<ImmutableList<TeamEntity>> GetTeamsWithDefaultAsync(int categoryId, int manufacturerId)
		{
			var teams = await GetTeamsAsync(categoryId, manufacturerId);
			return teams.AddDefaultValue(new TeamEntity(0, "ALL"));
		}
	}
}
