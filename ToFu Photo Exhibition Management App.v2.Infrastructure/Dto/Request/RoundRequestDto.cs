namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Request
{
	public class RoundRequestDto
	{
		public RoundRequestDto(int id, string name, int categoryId)
		{
			Id = id;
			Name = name;
			CategoryId = categoryId;
		}
		public int Id { get; }
		public string Name { get; }
		public int CategoryId { get; }
	}
}