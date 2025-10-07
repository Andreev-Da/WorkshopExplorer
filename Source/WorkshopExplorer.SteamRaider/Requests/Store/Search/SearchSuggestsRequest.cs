using System.Text;
using System.Web;

namespace WorkshopExplorer.SteamRaider.Requests.Store.Search;


//search/suggest?term=123&f=games&cc=RU&realm=1&l=russian&v=30266810&use_store_query=1&use_search_spellcheck=1&search_creators_and_tags=1
public sealed class SearchSuggestsRequest : BaseSteamRequest<List<FoundSuggest>>
{
    private readonly SteamClient _client;
    
    public SearchSuggestsRequest(SteamClient client) : base()
    {
        _client = client;
        Currency = _client.Config.Currency;
        Language = _client.Config.Language;
    }

    public string Currency { get; set; }
    public string Language { get; set; }
    public string? Term { get; set => SetValueAndNullUri(ref field, in value); }
    
    public override async Task<List<FoundSuggest>> SendAsync(CancellationToken cancellationToken = default)
    {
        List<FoundSuggest> suggests = new();
        for(int i = 0; i < Random.Shared.Next(10); i++)
        {
            suggests.Add(
                new FoundSuggest(
                    $"test{i}",
                    "https://store.steampowered.com/app/2426210/Sim_Racing_Telemetry__F1_23?snr=1_7_15__13",
                    "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2426210/b616fd0c99ed9af5f1fba9dc3e8064232375fd10/capsule_231x87.jpg?t=1727977870",
                    null,
                    FoundSuggestType.App
                )   
            );
        }

        return suggests;
        // Uri uri = GetOrCreateUri();
        // return _client.HttpClient.SendAsync(
        //     HttpMethod.Get, uri, 
        //     SearchSuggestResponseParser.Instance, 
        //     cancellationToken
        // );
    }
    
    
    private Uri GetOrCreateUri()
    {
        if (Uri is not null)
            return Uri;
        
        string url = Path.Join(SteamUrl.Store, "/search/suggest");
        string normalizedTerm = HttpUtility.UrlDecode(Term) ?? throw new InvalidOperationException("Term is null");
        
        const int punctuatorsLength = 21;
        int capacity = punctuatorsLength
            + url.Length
            + Currency.Length
            + Language.Length
            + normalizedTerm.Length;
        
        StringBuilder uriString = new(capacity);
        uriString.Append(url);
        uriString.Append("?term=").Append(normalizedTerm);
        uriString.Append("&f=games");
        uriString.Append("&cc=").Append(Currency);
        uriString.Append("&l=").Append(Language);
        
        Uri = new Uri(uriString.ToString());
        return Uri;
    }


}