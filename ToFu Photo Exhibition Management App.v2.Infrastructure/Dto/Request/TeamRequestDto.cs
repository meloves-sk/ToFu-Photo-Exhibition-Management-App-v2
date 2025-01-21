namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Request
{
	public class TeamRequestDto
	{
        public TeamRequestDto(int id,string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; }
		public string Name { get; }
	}
}
