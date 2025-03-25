using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Request;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Response;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI
{
	public class TeamInformationRepository : ITeamInformationRepository
	{
		public async Task<ImmutableList<TeamInformationEntity>> GetTeamInformationsAsync(Id? categoryId, Id? manufacturerId)
		{
			if (!Guard.NotAllNull(categoryId, manufacturerId))
			{
				return ImmutableList<TeamInformationEntity>.Empty;
			}
			var result = await APIHelper.Get<ServiceResponse<IEnumerable<TeamInformationResponseDto>>>($"api/teaminformation/category/{categoryId?.Value}/manufacturer/{manufacturerId?.Value}/team/0");
			Guard.IsNull(result, "チーム情報の取得に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Data
				.Select(a => new TeamInformationEntity(
					a.Id,
					a.TeamId,
					a.ManufacturerId,
					a.CategoryId,
					a.Team,
					a.Manufacturer,
					a.Category))
				.ToImmutableList();
		}

		public async Task<string> SaveTeamInformationAsync(Id? teamInformationId, Id teamId, Id manufacturerId, Id categoryId)
		{
			var request = new TeamInformationRequestDto(teamInformationId == null ? 0 : teamInformationId.Value, teamId.Value, manufacturerId.Value, categoryId.Value);
			var result = teamId == null
				? await APIHelper.Post("api/teaminformation", request)
				: await APIHelper.Put("api/teaminformation", request);
			Guard.IsNull(result, "チーム情報の保存に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Message;
		}

		public async Task<string> DeleteTeamInformationAsync(Id teamInformationId)
		{
			var result = await APIHelper.Delete($"api/teaminformation/{teamInformationId.Value}");
			Guard.IsNull(result, "チーム情報の削除に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Message;
		}
	}
}
