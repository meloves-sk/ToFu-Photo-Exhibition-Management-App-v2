namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class Car : ValueObject<Car>
	{
		public Car(string value)
		{
			Value = value;
		}
		public string Value { get; }
		protected override bool EqualsCore(Car other)
		{
			return Value == other.Value;
		}
	}
}
