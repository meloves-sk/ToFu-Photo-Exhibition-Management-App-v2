namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class CarNo : ValueObject<CarNo>
	{
		public CarNo(int value)
		{
			Value = value;
		}
		public int Value { get; }
		protected override bool EqualsCore(CarNo other)
		{
			return Value == other.Value;
		}
	}
}
