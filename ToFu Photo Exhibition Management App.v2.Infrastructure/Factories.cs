using ToFuPhotoExhibitionManagementApp.v2.Domain;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dammy;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure
{
	public static class Factories
	{
		public static ICategoryRepository CreateCategoryRepository()
		{
			if (Shared.IsDammy)
			{
				return new DammyCategoryRepository();
			}
			return new CategoryRepository();
		}
		public static IRoundRepository CreateRoundRepository()
		{
			if (Shared.IsDammy)
			{
				return new DammyRoundRepository();
			}
			return new RoundRepository();
		}
		public static IManufacturerRepository CreateManufacturerRepository()
		{
			if (Shared.IsDammy)
			{
				return new DammyManufacturerRepository();
			}
			return new ManufacturerRepository();
		}
		public static ITeamRepository CreateTeamRepository()
		{
			if (Shared.IsDammy)
			{
				return new DammyTeamRepository();
			}
			return new TeamRepository();
		}
		public static ITeamInformationRepository CreateTeamInformationRepository()
		{
			if (Shared.IsDammy)
			{
				return new DammyTeamInformationRepository();
			}
			return new TeamInformationRepository();
		}
		public static ICarRepository CreateCarRepository()
		{
			if (Shared.IsDammy)
			{
				return new DammyCarRepository();
			}
			return new CarRepository();
		}
		public static IPhotoRepository CreatePhotoRepository()
		{
			if (Shared.IsDammy)
			{
				return new DammyPhotoRepository();
			}
			return new PhotoRepository();
		}
	}
}
