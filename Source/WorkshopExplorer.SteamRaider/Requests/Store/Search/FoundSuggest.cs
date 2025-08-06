using WorkshopExplorer.SteamRaider.Values;

namespace SteamWorkshopExplorer.PageParser.Models;

public record FoundSuggest(
    string Name,
    SteamUrl ReferenceUrl,
    SteamUrl ImageUrl
);