using System.Text.RegularExpressions;

namespace WorkshopExplorer.SteamRaider.Requests.Store.Search;

public partial class SearchSuggestResponseParser : IResponseParser<List<FoundSuggest>>
{
    private static readonly Regex ItemRegex = CreateItemRegex();

    public static SearchSuggestResponseParser Instance { get; } = new();
    
    public async Task<List<FoundSuggest>> ParseAsync(HttpResponseMessage response, CancellationToken cancellationToken = default)
    {
        string content = await response.Content.ReadAsStringAsync(cancellationToken);
        MatchCollection matches = ItemRegex.Matches(content);

        var result = new List<FoundSuggest>(matches.Count);
        for (int i = 0; i < matches.Count; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            GroupCollection matchedGroups = matches[i].Groups;
            var item = new FoundSuggest(
                matchedGroups[3].Value,
                matchedGroups[1].Value,
                matchedGroups[3].Value,
                matchedGroups[2].Value,
                FoundSuggestType.App
            );
            
            result.Add(item);
        }

        return result;
    }
    
    [GeneratedRegex(
        @"<a.*?(?:href=""""(.*?)"""")(?:>\s*<div\s*class=""""match_background_image""""\s*?>\s*<img\s*?src=""""(.*?)""""\s*?>)?.*?<div.+?match_name.*?>\s*(.*?)\s*</div>\s*<div.*?<img\s*?src=""""(.*?)""""\s*?>.*?<div.+?match_subtitle.*?>\s*(.*?)\s*</div>.*?</a>",
        RegexOptions.Compiled | RegexOptions.Singleline)]
    private static partial Regex CreateItemRegex();
}
