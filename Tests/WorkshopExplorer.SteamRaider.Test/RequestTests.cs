using SteamWorkshopExplorer.PageParser;
using SteamWorkshopExplorer.PageParser.Models;
using SteamWorkshopExplorer.PageParser.Requests.Find;

namespace WorkshopExplorer.SteamRaider.Test;

public class RequestTests
{
    private readonly SteamClient _client;
    
    public RequestTests()
    {
        SteamClientConfig config = new();
        _client = new SteamClient(config);
    }
    

    [Theory]
    public async Task Search()
    {
        SearchSuggestRequest search = new(_client);
        search.Term = "PalWorld";

        List<SearchSuggestItem> searchResult = await search.SendAsync();
        
        Assert.Pass();
    }
}