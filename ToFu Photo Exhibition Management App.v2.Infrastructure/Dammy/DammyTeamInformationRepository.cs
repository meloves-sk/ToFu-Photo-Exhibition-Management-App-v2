using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dammy
{
	public class DammyTeamInformationRepository : ITeamInformationRepository
	{
		public Task<ImmutableList<TeamInformationEntity>> GetTeamInformationsAsync(Id? categoryId, Id? manufacturerId)
		{
			throw new NotImplementedException();
		}

		public Task<string> SaveTeamInformationAsync(Id? teamInformationId, Id teamId, Id manufacturerId, Id categoryId)
		{
			throw new NotImplementedException();
		}
		public Task<string> DeleteTeamInformationAsync(Id teamInformationId)
		{
			throw new NotImplementedException();
		}

	}
}
