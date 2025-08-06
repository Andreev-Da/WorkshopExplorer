namespace WorkshopExplorer.SteamRaider.Requests;

public abstract class BaseSteamRequest<TResponse> : ISteamRequest<TResponse>
{
    protected Uri? Uri { get; set; }

    public abstract Task<TResponse> SendAsync(CancellationToken cancellationToken = default);
    
    protected void SetValueAndNullUri<TValue>(ref TValue field, in TValue value)
    {
        field = value;
        Uri = null;
    }
}