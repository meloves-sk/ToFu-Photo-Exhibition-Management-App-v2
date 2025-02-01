using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface IRoundRepository
	{
		Task<ImmutableList<RoundEntity>> GetRoundsAsync(Id? categoryId);
		Task<ImmutableList<RoundEntity>> GetRoundsWithDefaultAsync(Id? categoryId);
	}
}
