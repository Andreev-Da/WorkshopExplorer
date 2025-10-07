using System;
using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using WorkshopExplorer.Pages;
using WorkshopExplorer.Shared;
using WorkshopExplorer.Shared.Routing;

namespace WorkshopExplorer.Application;

internal partial class MainViewModel : ViewModelBase, IDisposable
{
    private IRouter<PageViewModel> _router;
    [ObservableProperty]
    private string _themeVariant = "Light";
    private Timer _timer;

    public MainViewModel(IRouter<PageViewModel> router)
    {
        _router = router;
        _router.CurrentPageChanged += RouterPageChangedHandler;
        _timer = new Timer();
        _timer.Elapsed += (_, _) =>
        {
            ThemeVariant = "Dark";
        };
        _timer.Interval = TimeSpan.FromSeconds(2).TotalMilliseconds;
        _timer.Start();
    }
    public PageViewModel ContentViewModel => _router.Current;

    private void RouterPageChangedHandler(PageViewModel? oldPage, PageViewModel newPage)
    {
        if (oldPage != newPage)
            OnPropertyChanged(nameof(ContentViewModel));
    }
    
    public void Dispose()
    {
        _router.CurrentPageChanged -= RouterPageChangedHandler;
    }
}