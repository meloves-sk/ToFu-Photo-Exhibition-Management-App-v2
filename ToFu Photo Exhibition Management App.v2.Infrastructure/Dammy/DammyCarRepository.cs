using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dammy
{
	public class DammyCarRepository : ICarRepository
	{
		private List<CarEntity> _cars = new List<CarEntity>();
		public DammyCarRepository()
		{
			_cars.Add(new CarEntity(1, "Car1", 1, 1, "Team1", "Manufacturer1", "Category1"));
			_cars.Add(new CarEntity(2, "Car2", 1, 2, "Team2", "Manufacturer2", "Category2"));
			_cars.Add(new CarEntity(3, "Car3", 1, 3, "Team3", "Manufacturer3", "Category3"));
		}

		public async Task<ImmutableList<CarEntity>> GetCarsAsync(Id? categoryId, Id? manufacturerId, Id? teamId)
		{
			await Task.CompletedTask;
			return _cars.ToImmutableList();
		}

		public async Task<ImmutableList<CarEntity>> GetCarsWithDefaultAsync(Id? categoryId, Id? manufacturerId, Id? teamId)
		{
			var cars = await GetCarsAsync(categoryId, manufacturerId, teamId);
			return cars.AddDefaultValue(new CarEntity(0, "ALL", 0, 0, string.Empty, string.Empty, string.Empty));
		}

		public async Task<string> SaveCarAsync(Id? carId, string name, int carNo, Id teamInformationId)
		{
			await Task.CompletedTask;
			_cars.Add(new CarEntity(4, "Car4", 1, 4, "Team4", "Manufacturer4", "Category4"));
			return "Success";
		}

		public async Task<string> DeleteCarAsync(Id carId)
		{
			await Task.CompletedTask;
			_cars.Remove(_cars.First(a => a.Id.Value == 1));
			return "Success";
		}
	}
}
