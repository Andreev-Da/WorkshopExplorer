using System;
using Microsoft.Extensions.DependencyInjection;
using WorkshopExplorer.Pages;

namespace WorkshopExplorer.Shared.Routing;

/// <summary>
/// Простой роутер, без реализации истории маршрутизации, из-за чего Push работает аналогично Replace 
/// </summary>
public partial class SimpleRouter: IRouter<PageViewModel>
{
    private readonly IServiceProvider _services;
    private readonly Type _homePage;
    
    private PageViewModel? _current;
    
    public SimpleRouter(IServiceProvider services, SimpleRouterConfig config)
    {
        if (!config.HomePageType.IsAssignableTo(typeof(PageViewModel)))
            throw new ArgumentException($"{nameof(config.HomePageType)} must be assignable to PageViewModel");
        
        _services = services;
        _homePage = config.HomePageType;
    }

    public PageViewModel Current
    {
        get => GetCurrentPageOrInitValue(); 
        private set => SetCurrentPageAndRiseEvent(value);
    }
    
    private PageViewModel GetCurrentPageOrInitValue()
    {
        _current ??= _services.GetRequiredService(_homePage) as PageViewModel;
        
        if (_current == null)
            throw new InvalidOperationException("The page was not found, although it should have been.");
        
        return _current;
    }
    
    private void SetCurrentPageAndRiseEvent(PageViewModel value)
    {
        PageViewModel? old = _current;
        _current = value;
        
        CurrentPageChanged?.Invoke(old, value);
    }

    public event PageChangedEventHandler<PageViewModel>? CurrentPageChanged;
    
    public void Push<TPage>() where TPage : PageViewModel
        => Replace<TPage>();
    
    public void Replace<TPage>() where TPage : PageViewModel
        => ReplaceInternal(_services.GetRequiredService<TPage>());

    public void Push<TPage>(Action<TPage> initializer) where TPage : PageViewModel
        => Replace(initializer);
    
    public void Replace<TPage>(Action<TPage> initializer) where TPage : PageViewModel
    {
        ArgumentNullException.ThrowIfNull(initializer);
        
        TPage page = _services.GetRequiredService<TPage>();
        initializer(page);
        
        ReplaceInternal(page);
    }
    
    private void ReplaceInternal(PageViewModel page)
    {
        Current = page;
    }
}