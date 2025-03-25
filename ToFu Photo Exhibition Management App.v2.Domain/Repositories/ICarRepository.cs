using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface ICarRepository
	{
		Task<ImmutableList<CarEntity>> GetCarsAsync(Id? categoryId, Id? manufacturerId, Id? teamId);
		Task<ImmutableList<CarEntity>> GetCarsWithDefaultAsync(Id? categoryId, Id? manufacturerId, Id? teamId);
		Task<string> SaveCarAsync(Id? carId, string name, int carNo, Id teamInformationId);
		Task<string> DeleteCarAsync(Id carId);
	}
}
