using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface ICarRepository
	{
		Task<ImmutableList<CarEntity>> GetCarsAsync(int categoryId, int manufacturerId, int teamId);
		Task<ImmutableList<CarEntity>> GetCarsWithDefaultAsync(int categoryId, int manufacturerId, int teamId);
	}
}
