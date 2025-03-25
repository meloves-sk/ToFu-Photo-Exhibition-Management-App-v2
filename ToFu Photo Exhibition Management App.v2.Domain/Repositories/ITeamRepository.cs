using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface ITeamRepository
	{
		Task<ImmutableList<TeamEntity>> GetTeamsAsync(Id? categoryId, Id? manufacturerId);
		Task<ImmutableList<TeamEntity>> GetTeamsWithDefaultAsync(Id? categoryId, Id? manufacturerId);
		Task<string> SaveTeamAsync(Id? teamId, string name);
		Task<string> DeleteTeamAsync(Id teamId);
	}
}
