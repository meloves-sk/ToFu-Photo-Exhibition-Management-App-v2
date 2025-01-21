namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class Id : ValueObject<Id>
	{
		public Id(int value)
		{
			Value = value;
		}
		public int Value { get; }
		protected override bool EqualsCore(Id other)
		{
			return Value == other.Value;
		}
	}
}
