namespace WorkshopExplorer.SteamRaider.Requests.Store.Search;

public enum FoundSuggestType
{
    Unknown,
    App,
    Tag,
    Creator,
}

public record FoundSuggest(
    string Name,
    string Reference,
    string Preview,
    string? Background,
    FoundSuggestType Tags
);