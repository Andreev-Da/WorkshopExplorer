using CommunityToolkit.Mvvm.ComponentModel;
using SteamWorkshopExplorer.Widgets.Search;

namespace SteamWorkshopExplorer.Pages.HomePage;

public partial class HomePageModel(SearchWidgetModel searchWidget) : PageViewModel
{
    [ObservableProperty] private SearchWidgetModel _searchWidget = searchWidget;
}