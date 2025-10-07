namespace WorkshopExplorer.SteamRaider;

internal interface IResponseParser<T>
{
    Task<T> ParseAsync(HttpResponseMessage response, CancellationToken cancellationToken = default);
}