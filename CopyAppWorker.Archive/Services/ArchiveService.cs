using System.IO.Compression;
using CopyAppWorker.Archive.Interfaces;
using CopyAppWorker.Logging.Interfaces;

namespace CopyAppWorker.Archive.Services;

public class ArchiveService : IArchiveService
{
    private readonly ILoggingService _loggingService;

    public ArchiveService(ILoggingService loggingService)
    {
        _loggingService = loggingService;
    }

    public async void ToArchive(string path)
    {
        _loggingService.DebugLog("Archivation started");
        try {
            ZipFile.CreateFromDirectory(path, path + @".zip");
        } catch (Exception e){
            _loggingService.ErrorLog("Archivation failed");
            throw;
        }

        _loggingService.DebugLog("Archivation finished");
    }
}