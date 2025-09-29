using System;
using Jab;
using SteamWorkshopExplorer.PageParser;
using SteamWorkshopExplorer.Pages;
using SteamWorkshopExplorer.Pages.Bitmap;
using SteamWorkshopExplorer.Pages.HomePage;
using SteamWorkshopExplorer.Shared.Routing;
using SteamWorkshopExplorer.Widgets.Search;
using WorkshopExplorer.SteamRaider;

namespace SteamWorkshopExplorer.Application;

[ServiceProvider]
[Singleton<SteamClient>(Factory = nameof(SteamClientFactory))]
[Singleton<IRouter<PageViewModel>>(Factory = nameof(PageRouterFactory))]
[Singleton<MainViewModel>]
[Transient<BitmapTestPageModel>]
[Transient<SearchWidgetModel>]
[Transient<HomePageModel>]
internal partial class ApplicationServiceProvider : IServiceProvider
{
    public static IRouter<PageViewModel> PageRouterFactory(IServiceProvider services)
    {
        SimpleRouterConfig config = new SimpleRouterConfig(
            HomePageType: typeof(HomePageModel)
        );
        return new SimpleRouter(services, config);
    }

    public static SteamClient SteamClientFactory(IServiceProvider services)
    {
        SteamClient client = new(
            new SteamClientConfig()
        );
        
        return client;
    }
};