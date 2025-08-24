using ARPSynchronos.API.Data;
using ARPSynchronos.FileCache;
using ARPSynchronos.Services.CharaData.Models;

namespace ARPSynchronos.Services.CharaData;

public sealed class ARPCharaFileDataFactory
{
    private readonly FileCacheManager _fileCacheManager;

    public ARPCharaFileDataFactory(FileCacheManager fileCacheManager)
    {
        _fileCacheManager = fileCacheManager;
    }

    public ARPCharaFileData Create(string description, CharacterData characterCacheDto)
    {
        return new ARPCharaFileData(_fileCacheManager, description, characterCacheDto);
    }
}