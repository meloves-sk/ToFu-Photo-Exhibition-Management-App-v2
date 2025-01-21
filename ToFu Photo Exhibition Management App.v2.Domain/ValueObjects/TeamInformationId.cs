namespace ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects
{
	public class TeamInformationId : ValueObject<TeamInformationId>
	{
		public TeamInformationId(int value)
		{
			Value = value;
		}
		public int Value { get; }
		protected override bool EqualsCore(TeamInformationId other)
		{
			return Value == other.Value;
		}
	}
}
