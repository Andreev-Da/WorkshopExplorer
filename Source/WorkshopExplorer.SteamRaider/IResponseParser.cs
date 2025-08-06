namespace SteamWorkshopExplorer.PageParser.Parsers;

internal interface IResponseParser<T>
{
    Task<T> ParseAsync(HttpResponseMessage response, CancellationToken cancellationToken = default);
}