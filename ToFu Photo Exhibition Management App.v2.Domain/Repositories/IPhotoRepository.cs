using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface IPhotoRepository
	{
		Task<ImmutableList<PhotoEntity>> GetPhotosAsync(int? categoryId, int? roundId, int? manufacturerId, int? teamId, int? carId);
		Task<string>AddPhotoAsync(int? photoId,)
		Task<string> DeletePhotoAsync(int photoId);
	}
}
