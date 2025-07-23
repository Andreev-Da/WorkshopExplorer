using System;
using Jab;
using SteamWorkshopExplorer.Pages;
using SteamWorkshopExplorer.Pages.HomePage;
using SteamWorkshopExplorer.Shared.Routing;

namespace SteamWorkshopExplorer.Application;

[ServiceProvider]
[Singleton<IRouter<PageViewModel>>(Factory = nameof(SimpleRouterFactory))]
[Transient<MainViewModel>]
[Transient<HomePageViewModel>]
internal partial class ApplicationServiceProvider : IServiceProvider
{
    public IRouter<PageViewModel> SimpleRouterFactory(IServiceProvider services)
    {
        SimpleRouterConfig config = new SimpleRouterConfig(
            HomePageType: typeof(HomePageViewModel)
        );
        return new SimpleRouter(services, config);
    }
};