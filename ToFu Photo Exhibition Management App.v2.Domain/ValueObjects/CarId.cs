namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class CarId : ValueObject<CarId>
	{
		public CarId(int value)
		{
			Value = value;
		}
		public int Value { get; }
		protected override bool EqualsCore(CarId other)
		{
			return Value == other.Value;
		}
	}
}
