using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface IPhotoRepository
	{
		Task<ImmutableList<PhotoEntity>> GetPhotosAsync(Id? categoryId, Id? roundId, Id? manufacturerId, Id? teamId, Id? carId);
		Task<string> SavePhotoAsync(Id? photoId, string description, Id roundId, Id carId, string filePath);
		Task<string> DeletePhotoAsync(Id photoId);
	}
}
