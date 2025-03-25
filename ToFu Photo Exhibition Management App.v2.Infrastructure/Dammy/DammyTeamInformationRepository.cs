using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dammy
{
	public class DammyTeamInformationRepository : ITeamInformationRepository
	{
		private List<TeamInformationEntity> _teamInformations = new List<TeamInformationEntity>();
		public DammyTeamInformationRepository()
		{
			_teamInformations.Add(new TeamInformationEntity(1, 1, 1, 1, "Team1", "Manufacturer1", "Category1"));
			_teamInformations.Add(new TeamInformationEntity(2, 2, 2, 2, "Team2", "Manufacturer2", "Category2"));
			_teamInformations.Add(new TeamInformationEntity(3, 3, 3, 3, "Team3", "Manufacturer3", "Category3"));
		}
		public async Task<ImmutableList<TeamInformationEntity>> GetTeamInformationsAsync(Id? categoryId, Id? manufacturerId)
		{
			await Task.CompletedTask;
			return _teamInformations.ToImmutableList();
		}

		public async Task<string> SaveTeamInformationAsync(Id? teamInformationId, Id teamId, Id manufacturerId, Id categoryId)
		{
			await Task.CompletedTask;
			_teamInformations.Add(new TeamInformationEntity(4, 4, 4, 4, "Team4", "Manufacturer4", "Category4"));
			return "Success";
		}
		public async Task<string> DeleteTeamInformationAsync(Id teamInformationId)
		{
			await Task.CompletedTask;
			_teamInformations.Remove(_teamInformations.First(a => a.Id.Value == 1));
			return "Success";
		}

	}
}
