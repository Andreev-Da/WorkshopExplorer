using System;

namespace WorkshopExplorer.Shared.Routing;

public delegate void PageChangedEventHandler<in TViewModel>(TViewModel? oldPage, TViewModel newPage);

public interface IRouter<TPage> where TPage : ViewModelBase
{
    event PageChangedEventHandler<TPage> CurrentPageChanged;
    TPage Current { get; }
 
    public void Push<TNewPage>(Action<TNewPage>? initializer = null) where TNewPage : TPage;
    public void Replace<TNewPage>(Action<TNewPage>? initializer = null) where TNewPage : TPage;
}