using System;
using Microsoft.Extensions.DependencyInjection;
using WorkshopExplorer.Pages;

namespace WorkshopExplorer.Shared.Routing;

/// <summary>
/// Простой роутер, без реализации истории маршрутизации, из-за чего Push работает аналогично Replace 
/// </summary>
public partial class SimpleRouter<TPage>: IRouter<TPage>
    where TPage : ViewModelBase
{
    private readonly IServiceProvider _services;
    private readonly Type _homePage;
    
    private TPage? _current;
    
    public SimpleRouter(IServiceProvider services, SimpleRouterConfig config)
    {
        if (!config.HomePageType.IsAssignableTo(typeof(TPage)))
            throw new ArgumentException($"{nameof(config.HomePageType)} must be assignable to TPage");
        
        _services = services;
        _homePage = config.HomePageType;
    }

    public TPage Current
    {
        get => GetCurrentPageOrInitValue(); 
        private set => SetCurrentPageAndRiseEvent(value);
    }
    
    private TPage GetCurrentPageOrInitValue()
    {
        _current ??= _services.GetRequiredService(_homePage) as TPage;
        
        if (_current == null)
            throw new InvalidOperationException("The page was not found, although it should have been.");
        
        return _current;
    }
    
    private void SetCurrentPageAndRiseEvent(TPage value)
    {
        TPage? old = _current;
        _current = value;
        
        CurrentPageChanged?.Invoke(old, value);
    }

    public event PageChangedEventHandler<TPage>? CurrentPageChanged;

    public void Push<TNewPage>(Action<TNewPage>? initializer) where TNewPage : TPage
        => Replace(initializer);
    
    public void Replace<TNewPage>(Action<TNewPage>? initializer) where TNewPage : TPage
    {
        TNewPage page = _services.GetRequiredService<TNewPage>();
        initializer?.Invoke(page);
        Current = page;
    }
}