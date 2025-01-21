using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories
{
	public interface ICategoryRepository
	{
		Task<ImmutableList<CategoryEntity>> GetCategoriesAsync();
		Task<ImmutableList<CategoryEntity>> GetCategoriesWithDefaultAsync();
	}
}
