using System.Collections.Immutable;
namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper
{
	public static class ListHelper
	{
		public static ImmutableList<T> AddDefaultValue<T>(this ImmutableList<T> list, T defaultValue)
		{
			return ImmutableList.Create(defaultValue).AddRange(list);
		}
	}
}
