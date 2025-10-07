using System.Text.Encodings.Web;
using WorkshopExplorer.SteamRaider.Requests.Store.Search;

namespace WorkshopExplorer.SteamRaider.Test;

public class RequestTests
{
    private readonly SteamClient _client;
    
    public RequestTests()
    {
        SteamClientConfig config = new();
        _client = new SteamClient(config);
    }
    
    /// <summary>
    /// Ленивый тест, просто проверяет что контент находится
    /// </summary>
    [Theory]
    public async Task SearchPalWorldSuggests()
    {
        SearchSuggestsRequest search = new(_client);
        search.Term = "PalWorld";

        List<FoundSuggest> searchResult = await search.SendAsync();
        Assert.That(searchResult.Count != 0, "PalWorld not found error");
        
        Assert.Pass();
    }
}