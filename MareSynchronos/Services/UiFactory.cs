using ARPSynchronos.API.Dto.Group;
using ARPSynchronos.PlayerData.Pairs;
using ARPSynchronos.Services.Mediator;
using ARPSynchronos.Services.ServerConfiguration;
using ARPSynchronos.UI;
using ARPSynchronos.UI.Components.Popup;
using ARPSynchronos.WebAPI;
using Microsoft.Extensions.Logging;

namespace ARPSynchronos.Services;

public class UiFactory
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ARPMediator _ARPMediator;
    private readonly ApiController _apiController;
    private readonly UiSharedService _uiSharedService;
    private readonly PairManager _pairManager;
    private readonly ServerConfigurationManager _serverConfigManager;
    private readonly ARPProfileManager _ARPProfileManager;
    private readonly PerformanceCollectorService _performanceCollectorService;

    public UiFactory(ILoggerFactory loggerFactory, ARPMediator ARPMediator, ApiController apiController,
        UiSharedService uiSharedService, PairManager pairManager, ServerConfigurationManager serverConfigManager,
        ARPProfileManager ARPProfileManager, PerformanceCollectorService performanceCollectorService)
    {
        _loggerFactory = loggerFactory;
        _ARPMediator = ARPMediator;
        _apiController = apiController;
        _uiSharedService = uiSharedService;
        _pairManager = pairManager;
        _serverConfigManager = serverConfigManager;
        _ARPProfileManager = ARPProfileManager;
        _performanceCollectorService = performanceCollectorService;
    }

    public SyncshellAdminUI CreateSyncshellAdminUi(GroupFullInfoDto dto)
    {
        return new SyncshellAdminUI(_loggerFactory.CreateLogger<SyncshellAdminUI>(), _ARPMediator,
            _apiController, _uiSharedService, _pairManager, dto, _performanceCollectorService);
    }

    public StandaloneProfileUi CreateStandaloneProfileUi(Pair pair)
    {
        return new StandaloneProfileUi(_loggerFactory.CreateLogger<StandaloneProfileUi>(), _ARPMediator,
            _uiSharedService, _serverConfigManager, _ARPProfileManager, _pairManager, pair, _performanceCollectorService);
    }

    public PermissionWindowUI CreatePermissionPopupUi(Pair pair)
    {
        return new PermissionWindowUI(_loggerFactory.CreateLogger<PermissionWindowUI>(), pair,
            _ARPMediator, _uiSharedService, _apiController, _performanceCollectorService);
    }
}
