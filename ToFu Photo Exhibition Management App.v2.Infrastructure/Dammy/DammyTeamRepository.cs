using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dammy
{
	internal class DammyTeamRepository : ITeamRepository
	{
		private List<TeamEntity> _teams = new List<TeamEntity>();
		public DammyTeamRepository()
		{
			_teams.Add(new TeamEntity(1, "Team1"));
			_teams.Add(new TeamEntity(2, "Team2"));
			_teams.Add(new TeamEntity(3, "Team3"));
		}
		public async Task<ImmutableList<TeamEntity>> GetTeamsAsync(int categoryId, int manufacturerId)
		{
			await Task.CompletedTask;
			return _teams.ToImmutableList();
		}

		public async Task<ImmutableList<TeamEntity>> GetTeamsWithDefaultAsync(int categoryId, int manufacturerId)
		{
			var teams = await GetTeamsAsync(categoryId, manufacturerId);
			return teams.AddDefaultValue(new TeamEntity(0, "ALL"));
		}
	}
}
