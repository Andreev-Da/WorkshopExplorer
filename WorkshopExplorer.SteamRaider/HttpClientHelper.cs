using SteamWorkshopExplorer.PageParser.Parsers;

namespace WorkshopExplorer.SteamRaider;

internal static class HttpClientHelper
{
    public static async Task<TResponse> SendAsync<TResponse>(
        this HttpClient client, 
        HttpMethod method, Uri uri, 
        IResponseParser<TResponse> parser, 
        CancellationToken cancellationToken = default
    ){
        var request = new HttpRequestMessage(method, uri);
        HttpResponseMessage response = await client.SendAsync(request, cancellationToken);
        
        return await parser.ParseAsync(response, cancellationToken);
    }
}