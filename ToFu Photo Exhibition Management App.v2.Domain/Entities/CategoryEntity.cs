using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;
namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Entities
{
	public class CategoryEntity
	{
		public CategoryEntity(int id, string name)
		{
			Id = new Id(id);
			Name = new Name(name);
		}
		public Id Id { get; }
		public Name Name { get; }
		public static bool IsNotNull(object? o)
		{
			return o != null;
		}
	}
}
