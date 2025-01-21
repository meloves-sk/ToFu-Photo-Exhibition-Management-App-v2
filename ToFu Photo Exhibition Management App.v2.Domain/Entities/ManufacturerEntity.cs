using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Entities
{
	public class ManufacturerEntity
	{
		public ManufacturerEntity(int id, string name)
		{
			Id = new Id(id);
			Name = new Name(name);
		}
		public Id Id { get; }
		public Name Name { get; }
	}
}
