using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dammy
{
	public class DammyManufacturerRepository : IManufacturerRepository
	{
		private List<ManufacturerEntity> _manufacturers = new List<ManufacturerEntity>();
		public DammyManufacturerRepository()
		{
			_manufacturers.Add(new ManufacturerEntity(1, "Manufacturer1"));
			_manufacturers.Add(new ManufacturerEntity(2, "Manufacturer2"));
			_manufacturers.Add(new ManufacturerEntity(3, "Manufacturer3"));
		}
		public async Task<ImmutableList<ManufacturerEntity>> GetManufacturersAsync(int categoryId)
		{
			await Task.CompletedTask;
			return _manufacturers.ToImmutableList();
		}

		public async Task<ImmutableList<ManufacturerEntity>> GetManufacturersWithDefaultAsync(int categoryId)
		{
			var manufacturers = await GetManufacturersAsync(categoryId);
			return manufacturers.AddDefaultValue(new ManufacturerEntity(0, "ALL"));
		}
	}
}
