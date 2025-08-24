using ARPSynchronos.ARPConfiguration.Configurations;

namespace ARPSynchronos.ARPConfiguration;

public class CharaDataConfigService : ConfigurationServiceBase<CharaDataConfig>
{
    public const string ConfigName = "charadata.json";

    public CharaDataConfigService(string configDir) : base(configDir) { }
    public override string ConfigurationName => ConfigName;
}