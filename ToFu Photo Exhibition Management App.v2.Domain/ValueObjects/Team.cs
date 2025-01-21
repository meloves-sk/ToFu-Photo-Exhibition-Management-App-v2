namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class Team : ValueObject<Team>
	{
		public Team(string value)
		{
			Value = value;
		}
		public string Value { get; }
		protected override bool EqualsCore(Team other)
		{
			return Value == other.Value;
		}
	}
}
