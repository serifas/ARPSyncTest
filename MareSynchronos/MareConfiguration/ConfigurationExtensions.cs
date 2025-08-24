using ARPSynchronos.ARPConfiguration.Configurations;

namespace ARPSynchronos.ARPConfiguration;

public static class ConfigurationExtensions
{
    public static bool HasValidSetup(this ARPConfig configuration)
    {
        return configuration.AcceptedAgreement && configuration.InitialScanComplete
                    && !string.IsNullOrEmpty(configuration.CacheFolder)
                    && Directory.Exists(configuration.CacheFolder);
    }
}