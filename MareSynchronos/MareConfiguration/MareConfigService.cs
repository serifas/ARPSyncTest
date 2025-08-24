using ARPSynchronos.ARPConfiguration.Configurations;

namespace ARPSynchronos.ARPConfiguration;

public class ARPConfigService : ConfigurationServiceBase<ARPConfig>
{
    public const string ConfigName = "config.json";

    public ARPConfigService(string configDir) : base(configDir)
    {
    }

    public override string ConfigurationName => ConfigName;
}