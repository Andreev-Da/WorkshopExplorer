using CommunityToolkit.Mvvm.Input;
using SteamWorkshopExplorer.Shared.Routing;

namespace SteamWorkshopExplorer.Pages.Bitmap;

public partial class BitmapTestPageModel(IRouter<PageViewModel> router) : PageViewModel
{
    [RelayCommand]
    private void Swap()
    {
        router.Push<PageViewModel>();
    }
}