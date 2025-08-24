using ARPSynchronos.ARPConfiguration.Models;

namespace ARPSynchronos.ARPConfiguration.Configurations;

public class ServerTagConfig : IARPConfiguration
{
    public Dictionary<string, ServerTagStorage> ServerTagStorage { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public int Version { get; set; } = 0;
}