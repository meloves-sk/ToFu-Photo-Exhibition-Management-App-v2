using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Response;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI
{
	internal class CategoryRepository : ICategoryRepository
	{
		public async Task<ImmutableList<CategoryEntity>> GetCategoriesAsync()
		{
			var result = await APIHelper.Get<ServiceResponse<IEnumerable<CategoryResponseDto>>>("api/category");
			Guard.IsNull(result, "カテゴリーの取得に失敗しました");
			Guard.IsFail(result.Success, result.Message);
			return result.Data
				.Select(a => new CategoryEntity(
					a.Id,
					a.Name))
				.ToImmutableList();
		}

		public async Task<ImmutableList<CategoryEntity>> GetCategoriesWithDefaultAsync()
		{
			var categories = await GetCategoriesAsync();
			return categories.AddDefaultValue(new CategoryEntity(0, "ALL"));
		}
	}
}
