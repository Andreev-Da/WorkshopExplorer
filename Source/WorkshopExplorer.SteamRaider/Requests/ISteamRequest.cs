namespace WorkshopExplorer.SteamRaider.Requests;

public interface ISteamRequest<T>
{
    public Task<T> SendAsync(CancellationToken cancellationToken = default);
}
