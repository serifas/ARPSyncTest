using ARPSynchronos.ARPConfiguration.Configurations;

namespace ARPSynchronos.ARPConfiguration;

public interface IConfigService<out T> : IDisposable where T : IARPConfiguration
{
    T Current { get; }
    string ConfigurationName { get; }
    string ConfigurationPath { get; }
    public event EventHandler? ConfigSave;
    void UpdateLastWriteTime();
}
