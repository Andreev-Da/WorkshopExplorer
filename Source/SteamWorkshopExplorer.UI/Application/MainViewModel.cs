using System;
using System.ComponentModel;
using SteamWorkshopExplorer.Pages;
using SteamWorkshopExplorer.Shared;
using SteamWorkshopExplorer.Shared.Routing;
using CommunityToolkit.Mvvm;

namespace SteamWorkshopExplorer.Application;

internal partial class MainViewModel : ViewModelBase, IDisposable
{
    private IRouter<PageViewModel> _router;
    
    public MainViewModel(IRouter<PageViewModel> router)
    {
        _router = router;
        _router.CurrentPageChanged += RouterPageChangedHandler;
    }
    public PageViewModel ContentViewModel => _router.Current;
    
    private void RouterPageChangedHandler(PageViewModel oldPage, PageViewModel newPage)
    {
        if (oldPage != newPage)
            OnPropertyChanged(nameof(ContentViewModel));
    }
    
    public void Dispose()
    {
        _router.CurrentPageChanged -= RouterPageChangedHandler;
    }
}