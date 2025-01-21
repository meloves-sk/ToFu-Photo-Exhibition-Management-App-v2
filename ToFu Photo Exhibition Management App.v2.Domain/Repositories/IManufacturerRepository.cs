using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface IManufacturerRepository
	{
		Task<ImmutableList<ManufacturerEntity>> GetManufacturersAsync(int categoryId);
		Task<ImmutableList<ManufacturerEntity>> GetManufacturersWithDefaultAsync(int categoryId);
	}
}
