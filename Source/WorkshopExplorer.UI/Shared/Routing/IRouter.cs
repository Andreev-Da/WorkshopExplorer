using System;
using System.ComponentModel;

namespace SteamWorkshopExplorer.Shared.Routing;

public delegate void PageChangedEventHandler<in TViewModel>(TViewModel? oldPage, TViewModel newPage);

public interface IRouter<TViewModel>
    where TViewModel : ViewModelBase
{
    
    TViewModel Current { get; }

    event PageChangedEventHandler<TViewModel> CurrentPageChanged;
    
    public void Push<TPage>() where TPage : TViewModel;
    public void Replace<TPage>() where TPage : TViewModel;
    
    public void Push<TPage>(Action<TPage> action) where TPage : TViewModel;
    public void Replace<TPage>(Action<TPage> initializer) where TPage : TViewModel;
}