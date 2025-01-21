using System.IO;
namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class FilePath : ValueObject<FilePath>
	{
		public FilePath(string value)
		{
			Value = Path.Combine(Shared.URL, value);
		}
		public string Value { get; }
		protected override bool EqualsCore(FilePath other)
		{
			return Value == other.Value;
		}
	}
}
