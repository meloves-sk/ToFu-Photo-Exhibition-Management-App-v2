using ToFuPhotoExhibitionManagementApp.v2.Domain;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;
namespace ToFuPhotoExhibitionManagementApp.v2.Test
{
	public class MainViewModelTest
	{
		[SetUp]
		public void Setup()
		{
			Shared.IsDammy = true;
		}

		[Test]
		public void 画面の初期値が正しい()
		{
			var viewModel = new MainViewModel();
			viewModel.CategoryList.Count.Is(0);
			viewModel.SelectedCategory.IsNull();
			viewModel.RoundList.Count.Is(0);
			viewModel.SelectedRound.IsNull();
			viewModel.ManufacturerList.Count.Is(0);
			viewModel.SelectedManufacturer.IsNull();
			viewModel.TeamList.Count.Is(0);
			viewModel.SelectedTeam.IsNull();
			viewModel.CarList.Count.Is(0);
			viewModel.SelectedCar.IsNull();
			viewModel.PhotoList.Count.Is(0);
		}

		[Test]
		public async Task 読み込み後の値が正しい()
		{
			var viewModel = new MainViewModel();
			await viewModel.InitializeAsync();
			viewModel.CategoryList.Count.Is(4);
			viewModel.SelectedCategory?.Name.Value.Is("ALL");
			viewModel.RoundList.Count.Is(4);
			viewModel.SelectedRound?.Name.Value.Is("ALL");
			viewModel.ManufacturerList.Count.Is(4);
			viewModel.SelectedManufacturer?.Name.Value.Is("ALL");
			viewModel.TeamList.Count.Is(4);
			viewModel.SelectedTeam?.Name.Value.Is("ALL");
			viewModel.CarList.Count.Is(4);
			viewModel.SelectedCar?.Name.Value.Is("ALL");
			viewModel.PhotoList.Count.Is(3);
		}

	}
}
