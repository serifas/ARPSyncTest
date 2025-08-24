using ARPSynchronos.API.Data;
using ARPSynchronos.API.Data.Comparer;
using ARPSynchronos.Interop.Ipc;
using ARPSynchronos.ARPConfiguration;
using ARPSynchronos.ARPConfiguration.Models;
using ARPSynchronos.Services.Mediator;
using System.Collections.Concurrent;

namespace ARPSynchronos.PlayerData.Pairs;

public class PluginWarningNotificationService
{
    private readonly ConcurrentDictionary<UserData, OptionalPluginWarning> _cachedOptionalPluginWarnings = new(UserDataComparer.Instance);
    private readonly IpcManager _ipcManager;
    private readonly ARPConfigService _ARPConfigService;
    private readonly ARPMediator _mediator;

    public PluginWarningNotificationService(ARPConfigService ARPConfigService, IpcManager ipcManager, ARPMediator mediator)
    {
        _ARPConfigService = ARPConfigService;
        _ipcManager = ipcManager;
        _mediator = mediator;
    }

    public void NotifyForMissingPlugins(UserData user, string playerName, HashSet<PlayerChanges> changes)
    {
        if (!_cachedOptionalPluginWarnings.TryGetValue(user, out var warning))
        {
            _cachedOptionalPluginWarnings[user] = warning = new()
            {
                ShownCustomizePlusWarning = _ARPConfigService.Current.DisableOptionalPluginWarnings,
                ShownHeelsWarning = _ARPConfigService.Current.DisableOptionalPluginWarnings,
                ShownHonorificWarning = _ARPConfigService.Current.DisableOptionalPluginWarnings,
                ShownMoodlesWarning = _ARPConfigService.Current.DisableOptionalPluginWarnings,
                ShowPetNicknamesWarning = _ARPConfigService.Current.DisableOptionalPluginWarnings
            };
        }

        List<string> missingPluginsForData = [];
        if (changes.Contains(PlayerChanges.Heels) && !warning.ShownHeelsWarning && !_ipcManager.Heels.APIAvailable)
        {
            missingPluginsForData.Add("SimpleHeels");
            warning.ShownHeelsWarning = true;
        }
        if (changes.Contains(PlayerChanges.Customize) && !warning.ShownCustomizePlusWarning && !_ipcManager.CustomizePlus.APIAvailable)
        {
            missingPluginsForData.Add("Customize+");
            warning.ShownCustomizePlusWarning = true;
        }

        if (changes.Contains(PlayerChanges.Honorific) && !warning.ShownHonorificWarning && !_ipcManager.Honorific.APIAvailable)
        {
            missingPluginsForData.Add("Honorific");
            warning.ShownHonorificWarning = true;
        }

        if (changes.Contains(PlayerChanges.Moodles) && !warning.ShownMoodlesWarning && !_ipcManager.Moodles.APIAvailable)
        {
            missingPluginsForData.Add("Moodles");
            warning.ShownMoodlesWarning = true;
        }

        if (changes.Contains(PlayerChanges.PetNames) && !warning.ShowPetNicknamesWarning && !_ipcManager.PetNames.APIAvailable)
        {
            missingPluginsForData.Add("PetNicknames");
            warning.ShowPetNicknamesWarning = true;
        }

        if (missingPluginsForData.Any())
        {
            _mediator.Publish(new NotificationMessage("Missing plugins for " + playerName,
                $"Received data for {playerName} that contained information for plugins you have not installed. Install {string.Join(", ", missingPluginsForData)} to experience their character fully.",
                NotificationType.Warning, TimeSpan.FromSeconds(10)));
        }
    }
}