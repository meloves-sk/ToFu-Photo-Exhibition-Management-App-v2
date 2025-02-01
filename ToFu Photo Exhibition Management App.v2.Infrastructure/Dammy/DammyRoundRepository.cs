using System.Collections.Immutable;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Helper;

namespace ToFuPhotoExhibitionManagementApp.v2.Infrastructure.Dammy
{
	public sealed class DammyRoundRepository : IRoundRepository
	{
		private List<RoundEntity> _rounds = new List<RoundEntity>();
		public DammyRoundRepository()
		{
			_rounds.Add(new RoundEntity(1, "Round1"));
			_rounds.Add(new RoundEntity(2, "Round2"));
			_rounds.Add(new RoundEntity(3, "Round3"));
		}
		public async Task<ImmutableList<RoundEntity>> GetRoundsAsync(Id? categoryId)
		{
			await Task.CompletedTask;
			return _rounds.ToImmutableList();
		}

		public async Task<ImmutableList<RoundEntity>> GetRoundsWithDefaultAsync(Id? categoryId)
		{
			var rounds = await GetRoundsAsync(categoryId);
			return rounds.AddDefaultValue(new RoundEntity(0, "ALL"));
		}
	}
}
