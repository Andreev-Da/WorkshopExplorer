using WorkshopExplorer.SteamRaider.Values;

namespace SteamWorkshopExplorer.PageParser.Models;

public record SearchSuggestItem(
    string Name,
    SteamUrl ReferenceUrl,
    SteamUrl ImageUrl
);