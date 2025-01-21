using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface ITeamRepository
	{
		Task<ImmutableList<TeamEntity>> GetTeamsAsync(int categoryId, int manufacturerId);
		Task<ImmutableList<TeamEntity>> GetTeamsWithDefaultAsync(int categoryId, int manufacturerId);
	}
}
