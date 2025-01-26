using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dammy
{
	public class DammyPhotoRepository : IPhotoRepository
	{
		private List<PhotoEntity> _photos = new List<PhotoEntity>();
		public DammyPhotoRepository()
		{
			_photos.Add(new PhotoEntity(1, "/Resource/tofu_photo_exhibition_logo.png", "Description1", 1, 1, "Round1", "Category1", "Car1", 1, "Team1", "Manufacturer1"));
			_photos.Add(new PhotoEntity(2, "/Resource/tofu_photo_exhibition_logo.png", "Description2", 2, 2, "Round2", "Category2", "Car2", 2, "Team2", "Manufacturer2"));
			_photos.Add(new PhotoEntity(3, "/Resource/tofu_photo_exhibition_logo.png", "Description3", 3, 3, "Round3", "Category3", "Car3", 3, "Team3", "Manufacturer3"));
		}
		public async Task<ImmutableList<PhotoEntity>> GetPhotosAsync(int? categoryId, int? roundId, int? manufacturerId, int? teamId, int? carId)
		{
			await Task.CompletedTask;
			return _photos.ToImmutableList();
		}
	}
}
