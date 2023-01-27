namespace WeatherApi.Services
{
    public interface IScopeInformation
    {
        Dictionary<string, string> HostScopeInfo { get; }
    }
}
