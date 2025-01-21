namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class Manufacturer : ValueObject<Manufacturer>
	{
		public Manufacturer(string value)
		{
			Value = value;
		}
		public string Value { get; }
		protected override bool EqualsCore(Manufacturer other)
		{
			return Value == other.Value;
		}
	}
}
