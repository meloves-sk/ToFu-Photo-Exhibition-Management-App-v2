namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class RoundId : ValueObject<RoundId>
	{
		public RoundId(int value)
		{
			Value = value;
		}
		public int Value { get; }
		protected override bool EqualsCore(RoundId other)
		{
			return Value == other.Value;
		}
	}
}
