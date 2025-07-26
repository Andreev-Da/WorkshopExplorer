using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Web;
using SteamWorkshopExplorer.PageParser.Models;
using SteamWorkshopExplorer.PageParser.Parsers;
using WorkshopExplorer.SteamRaider;
using WorkshopExplorer.SteamRaider.Requests;

namespace SteamWorkshopExplorer.PageParser.Requests.Find;


//search/suggest?term=123&f=games&cc=RU&realm=1&l=russian&v=30266810&use_store_query=1&use_search_spellcheck=1&search_creators_and_tags=1
public sealed class SearchSuggestRequest : BaseSteamRequest<List<SearchSuggestItem>>
{
    private readonly SteamClient _client;
    
    public SearchSuggestRequest(SteamClient client) : base()
    {
        _client = client;
        Currency = _client.Config.Currency;
        Language = _client.Config.Language;
    }

    public string Currency { get; set; }
    public string Language { get; set; }
    public string? Term { get; set => SetValueAndNullUri(ref field, in value); }
    
    public override Task<List<SearchSuggestItem>> SendAsync(CancellationToken cancellationToken = default)
    {
        Uri uri = GetOrCreateUri();
        return _client.HttpClient.SendAsync(
            HttpMethod.Get, uri, 
            SearchSuggestResponseParser.Instance, 
            cancellationToken
        );
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