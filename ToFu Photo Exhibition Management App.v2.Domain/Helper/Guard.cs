using System.Collections.Immutable;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Helper
{
	public static class Guard
	{
		public static void IsNull(object? o, string message)
		{
			if (o == null)
			{
				throw new Exception(message);
			}
		}
		public static bool NotAllNull(params object?[] objects)
		{
			return objects.All(a => a != null);
		}

		public static void IsFail(bool success, string message)
		{
			if (!success)
			{
				throw new Exception(message);
			}
		}
	}
}
