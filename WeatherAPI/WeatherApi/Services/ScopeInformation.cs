using System.Reflection;

namespace WeatherApi.Services
{
    public class ScopeInformation : IScopeInformation
    {
        public ScopeInformation()
        {
            HostScopeInfo = new Dictionary<string, string>
            {
                {"MachineName", Environment.MachineName },
                {"EntryPoint", Assembly.GetEntryAssembly().GetName().Name}
            };
        }

        public Dictionary<string, string> HostScopeInfo { get; }
    }
}
