namespace WorkshopExplorer.SteamRaider;

public class SteamClient
{
    public SteamClient(SteamClientConfig config)
    {
        HttpClient = new HttpClient();
        Config = config;
    }
    
    public SteamClientConfig Config { get; }
    public HttpClient HttpClient { get; }
}