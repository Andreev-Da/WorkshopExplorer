using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SteamWorkshopExplorer.PageParser.Models;
using SteamWorkshopExplorer.PageParser.Requests.Find;
using SteamWorkshopExplorer.Shared;
using WorkshopExplorer.SteamRaider;

namespace SteamWorkshopExplorer.Widgets.Search;

public partial class SearchWidgetModel(SteamClient steamClient) : ViewModelBase
{
    private readonly SteamClient _steamClient = steamClient;
    
    [ObservableProperty]
    private string _searchText = String.Empty;
    
    public ObservableCollection<FoundSuggest> Suggests { get; } = new();

    partial void OnSearchTextChanged(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
            return;
        
        SearchSuggests(searchText).ContinueWith(x =>
        {
            ///TODO Logging
        });
    }

    private async Task SearchSuggests(string searchText,  CancellationToken cancellation = default)
    {
        SearchSuggestsRequest searchRequest = new(steamClient)
        {
            Term = searchText
        };

        cancellation.ThrowIfCancellationRequested();
        List<FoundSuggest> suggests = await searchRequest.SendAsync(cancellation);

        int i = -1;
        foreach (FoundSuggest suggest in suggests.OrderBy(x => x.Name))
        {
            i++;
            if (Suggests.Contains(suggest))
                continue;
            
            Suggests.Insert(i, suggest);
        }
    }
}