using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface IRoundRepository
	{
		Task<ImmutableList<RoundEntity>> GetRoundsAsync(int? categoryId);
		Task<ImmutableList<RoundEntity>> GetRoundsWithDefaultAsync(int? categoryId);
	}
}
