namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class Description : ValueObject<Description>
	{
		public Description(string value)
		{
			Value = value;
		}
		public string Value { get; }
		protected override bool EqualsCore(Description other)
		{
			return Value == other.Value;
		}
	}
}
