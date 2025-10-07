using System;
using Jab;
using WorkshopExplorer.Pages;
using WorkshopExplorer.Pages.Bitmap;
using WorkshopExplorer.Pages.Home;
using WorkshopExplorer.Shared.Routing;
using WorkshopExplorer.SteamRaider;
using WorkshopExplorer.Widgets.Search;

namespace WorkshopExplorer.Application;

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