﻿namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dto.Response
{
	public class RoundResponseDto
	{
		public RoundResponseDto(int id, string name)
		{
			Id = id;
			Name = name;
		}
		public int Id { get; }

		public string Name { get; }

	}
}
