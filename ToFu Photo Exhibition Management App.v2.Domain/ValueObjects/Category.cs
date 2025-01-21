namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class Category:ValueObject<Category>
	{
		public Category(string value)
		{
			Value = value;
		}
		public string Value { get; }
		protected override bool EqualsCore(Category other)
		{
			return Value == other.Value;
		}
	}
}
