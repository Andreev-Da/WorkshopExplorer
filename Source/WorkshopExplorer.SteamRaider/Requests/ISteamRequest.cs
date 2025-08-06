namespace WorkshopExplorer.SteamRaider;

public interface ISteamRequest<T>
{
    public Task<T> SendAsync(CancellationToken cancellationToken = default);
}
