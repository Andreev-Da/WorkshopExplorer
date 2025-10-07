using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Metadata;

namespace WorkshopExplorer.Shared.Views.Icons;

public class Icon : TemplatedControl
{
    public static readonly StyledProperty<IBrush> FillProperty 
        = AvaloniaProperty.Register<Icon, IBrush>(nameof(Fill));
    public IBrush Fill
    {
        get => GetValue(FillProperty);
        set => SetValue(FillProperty, value);
    }
}