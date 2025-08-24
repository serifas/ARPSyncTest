using ARPSynchronos.FileCache;
using ARPSynchronos.Services.Mediator;
using ARPSynchronos.WebAPI.Files;
using Microsoft.Extensions.Logging;

namespace ARPSynchronos.PlayerData.Factories;

public class FileDownloadManagerFactory
{
    private readonly FileCacheManager _fileCacheManager;
    private readonly FileCompactor _fileCompactor;
    private readonly FileTransferOrchestrator _fileTransferOrchestrator;
    private readonly ILoggerFactory _loggerFactory;
    private readonly ARPMediator _ARPMediator;

    public FileDownloadManagerFactory(ILoggerFactory loggerFactory, ARPMediator ARPMediator, FileTransferOrchestrator fileTransferOrchestrator,
        FileCacheManager fileCacheManager, FileCompactor fileCompactor)
    {
        _loggerFactory = loggerFactory;
        _ARPMediator = ARPMediator;
        _fileTransferOrchestrator = fileTransferOrchestrator;
        _fileCacheManager = fileCacheManager;
        _fileCompactor = fileCompactor;
    }

    public FileDownloadManager Create()
    {
        return new FileDownloadManager(_loggerFactory.CreateLogger<FileDownloadManager>(), _ARPMediator, _fileTransferOrchestrator, _fileCacheManager, _fileCompactor);
    }
}