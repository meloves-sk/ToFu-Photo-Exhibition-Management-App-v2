namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class Name : ValueObject<Name>
	{
		public Name(string value)
		{
			Value = value;
		}
		public string Value { get; }
		protected override bool EqualsCore(Name other)
		{
			return Value == other.Value;
		}
	}
}
