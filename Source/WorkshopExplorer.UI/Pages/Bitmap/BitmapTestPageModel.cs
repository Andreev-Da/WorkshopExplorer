using CommunityToolkit.Mvvm.Input;
using WorkshopExplorer.Shared.Routing;
using HomePageModel = WorkshopExplorer.Pages.Home.HomePageModel;

namespace WorkshopExplorer.Pages.Bitmap;

public partial class BitmapTestPageModel(IRouter<PageViewModel> router) : PageViewModel
{
    [RelayCommand]
    private void Swap()
    {
        router.Push<HomePageModel>();
    }
}