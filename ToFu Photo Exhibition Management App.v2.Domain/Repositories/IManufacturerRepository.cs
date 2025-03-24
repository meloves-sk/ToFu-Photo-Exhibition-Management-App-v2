using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface IManufacturerRepository
	{
		Task<ImmutableList<ManufacturerEntity>> GetManufacturersAsync(Id? categoryId);
		Task<ImmutableList<ManufacturerEntity>> GetManufacturersWithDefaultAsync(Id? categoryId);
		Task<string> SaveManufacturerAsync(Id? manufacturerId, string name);
		Task<string> DeleteManufacturerAsync(Id manufacturerId);
	}
}
