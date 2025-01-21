using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Entities
{
	public class CarEntity
	{
		public CarEntity(int id, string name, int carNo, int teamInformationId, string team, string manufacturer, string category)
		{
			Id = new Id(id);
			Name = new Name(name);
			CarNo = new CarNo(carNo);
			TeamInformationId = new TeamInformationId(teamInformationId);
			Team = new Team(team);
			Manufacturer = new Manufacturer(manufacturer);
			Category = new Category(category);
		}
		public Id Id { get; }
		public Name Name { get; }
		public CarNo CarNo { get; }
		public TeamInformationId TeamInformationId { get; }
		public Team Team { get; }
		public Manufacturer Manufacturer { get; }
		public Category Category { get; }
	}
}
