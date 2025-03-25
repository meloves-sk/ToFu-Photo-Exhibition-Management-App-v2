using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface ITeamInformationRepository
	{
		Task<ImmutableList<TeamInformationEntity>> GetTeamInformationsAsync(Id? categoryId, Id? manufacturerId);
		Task<string> SaveTeamInformationAsync(Id? teamInformationId, Id teamId, Id manufacturerId, Id categoryId);
		Task<string> DeleteTeamInformationAsync(Id teamInformationId);
	}
}
