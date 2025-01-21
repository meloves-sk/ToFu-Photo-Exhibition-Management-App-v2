using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;

namespace ToFuPhotoExhibitionManagementApp.v2.Domain.Entities
{
	public class PhotoEntity
	{
		public PhotoEntity(int id, string filePath, string description, int roundId, int carId, string round, string category, string car, int carNo, string team, string manufacturer)
		{
			Id = new Id(id);
			FilePath = new FilePath(filePath);
			Description = new Description(description);
			RoundId = new RoundId(roundId);
			CarId = new CarId(carId);
			Round = new Round(round);
			Category = new Category(category);
			Car = new Car(car);
			CarNo = new CarNo(carNo);
			Team = new Team(team);
			Manufacturer = new Manufacturer(manufacturer);
		}
		public Id Id { get; }
		public FilePath FilePath { get; }
		public Description Description { get; }
		public RoundId RoundId { get; }
		public CarId CarId { get; }
		public Round Round { get; }
		public Category Category { get; }
		public Car Car { get; }
		public CarNo CarNo { get; }
		public Team Team { get; }
		public Manufacturer Manufacturer { get; }
	}
}
