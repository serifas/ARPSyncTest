using ARPSynchronos.ARPConfiguration.Models;

namespace ARPSynchronos.ARPConfiguration.Configurations;

public class UidNotesConfig : IARPConfiguration
{
    public Dictionary<string, ServerNotesStorage> ServerNotes { get; set; } = new(StringComparer.Ordinal);
    public int Version { get; set; } = 0;
}
