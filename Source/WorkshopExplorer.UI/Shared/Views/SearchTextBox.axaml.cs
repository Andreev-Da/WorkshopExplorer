using WorkshopExplorer.Shared.Views.Icons;

namespace WorkshopExplorer.Shared.Views;

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