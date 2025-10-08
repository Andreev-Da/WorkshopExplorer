using CommunityToolkit.Mvvm.Input;
using WorkshopExplorer.Pages.Home;
using WorkshopExplorer.Shared.Routing;

namespace WorkshopExplorer.Pages.Bitmap;

public partial class BitmapTestPageModel(IRouter<PageViewModel> router) : PageViewModel
{
    [RelayCommand]
    private void Swap()
    {
        router.Push<HomePageModel>();
    }
}