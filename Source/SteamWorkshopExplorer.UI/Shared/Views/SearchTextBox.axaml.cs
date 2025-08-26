using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Metadata;
using SteamWorkshopExplorer.Shared.Icons;

namespace SteamWorkshopExplorer.Shared.Views;

public class SearchTextBox : TemplatedControl
{
    public static readonly StyledProperty<Control?> IconProperty = 
        AvaloniaProperty.Register<SearchTextBox, Control?>(nameof(Icon));

    public Control? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Icon ??= new SearchIcon();
    }
}