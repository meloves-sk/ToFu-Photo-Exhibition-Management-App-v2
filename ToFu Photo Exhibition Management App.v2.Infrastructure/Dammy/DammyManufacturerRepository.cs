using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;
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

		public async Task<ImmutableList<ManufacturerEntity>> GetManufacturersAsync(Id? categoryId)
		{
			await Task.CompletedTask;
			return _manufacturers.ToImmutableList();
		}

		public async Task<ImmutableList<ManufacturerEntity>> GetManufacturersWithDefaultAsync(Id? categoryId)
		{
			var manufacturers = await GetManufacturersAsync(categoryId);
			return manufacturers.AddDefaultValue(new ManufacturerEntity(0, "ALL"));
		}

		public async Task<string> SaveManufacturerAsync(Id? manufacturerId, string name)
		{
			await Task.CompletedTask;
			_manufacturers.Add(new ManufacturerEntity(4, name));
			return "Success";
		}
		public async Task<string> DeleteManufacturerAsync(Id manufacturerId)
		{
			await Task.CompletedTask;
			_manufacturers.Remove(_manufacturers.First(a => a.Id.Value == 1));
			return "Success";
		}
	}
}
