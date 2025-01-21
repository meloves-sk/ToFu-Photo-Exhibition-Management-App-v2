namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class Round : ValueObject<Round>
	{
		public Round(string value)
		{
			Value = value;
		}
		public string Value { get; }
		protected override bool EqualsCore(Round other)
		{
			return Value == other.Value;
		}
	}
}
