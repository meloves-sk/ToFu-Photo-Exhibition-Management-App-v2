namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Request
{ 
	public class ManufacturerRequestDto
	{
		public ManufacturerRequestDto(int id, string name)
		{
			Id = id;
			Name = name;
		}
		public int Id { get; }
		public string Name { get; }
	}
}