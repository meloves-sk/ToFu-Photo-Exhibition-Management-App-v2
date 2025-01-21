using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dammy
{
	public sealed class DammyCategoryRepository : ICategoryRepository
	{
		private List<CategoryEntity> _categories = new List<CategoryEntity>();
		public DammyCategoryRepository()
		{
			_categories.Add(new CategoryEntity(1, "Category1"));
			_categories.Add(new CategoryEntity(2, "Category2"));
			_categories.Add(new CategoryEntity(3, "Category3"));
		}
		public async Task<ImmutableList<CategoryEntity>> GetCategoriesAsync()
		{
			await Task.CompletedTask;
			return _categories.ToImmutableList();
		}

		public async Task<ImmutableList<CategoryEntity>> GetCategoriesWithDefaultAsync()
		{
			var categories = await GetCategoriesAsync();
			return categories.AddDefaultValue(new CategoryEntity(0, "ALL"));
		}
	}
}
