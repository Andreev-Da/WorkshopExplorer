using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using SteamWorkshopExplorer.PageParser.Models;
using WorkshopExplorer.SteamRaider.Values;

namespace SteamWorkshopExplorer.PageParser.Parsers;

public partial class SearchSuggestResponseParser : IResponseParser<List<SearchSuggestItem>>
{
    private static readonly Regex ItemRegex = CreateItemRegex();

    public static SearchSuggestResponseParser Instance { get; } = new();
    
    public async Task<List<SearchSuggestItem>> ParseAsync(HttpResponseMessage response, CancellationToken cancellationToken = default)
    {
        string content = await response.Content.ReadAsStringAsync(cancellationToken);
        MatchCollection matches = ItemRegex.Matches(content);

        var result = new List<SearchSuggestItem>(matches.Count);
        for (int i = 0; i < matches.Count; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            GroupCollection matchedGroups = matches[i].Groups;
            var item = new SearchSuggestItem(
                matchedGroups[2].Value,
                new SteamUrl(matchedGroups[1].Value),
                new SteamUrl(matchedGroups[3].Value)
            );
            
            result.Add(item);
        }

        return result;
    }
    
    /// <summary>
    /// Ожидаемая структура данных
    /// <!--
    /// <a class="match match_app match_v2 match_category_top ds_collapse_flag" data-ds-appid="2426210" data-ds-itemkey="0_2426210" href="(1){https://store.steampowered.com/app/2426210/Sim_Racing_Telemetry__F1_23?snr=1_7_15__13}">
    /// <div class="match_name ">(2){Sim Racing Telemetry - F1 23}</div>
    /// <div class="match_img">
    ///     <img src="(3){https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/2426210/b616fd0c99ed9af5f1fba9dc3e8064232375fd10/capsule_231x87.jpg?t=1727977870}">
    /// </div>
    /// <div class="match_subtitle">385 руб.</div>
    /// </a>
    /// -->
    /// </summary>
    /// <returns></returns>
    [GeneratedRegex(
        @"<a.*?(?:href=""(.*?)"").*?>.*?<div.+?match_name.*?>(.*?)</div>.*?<img.*?src=""(.*?)"".*?>.*?</a>",
        RegexOptions.Compiled | RegexOptions.Singleline)]
    private static partial Regex CreateItemRegex();
}
