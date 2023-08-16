using CopyAppWorker.Archive.Interfaces;
using CopyAppWorker.Copy.Interfaces;
using CopyAppWorker.Copy.Services;
using CopyAppWorker.Logging.Interfaces;

namespace CopyAppWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ILoggingService _loggingService;
    private readonly ICopyService _copyService;
    private readonly IArchiveService _archiveService;

    public Worker(ILogger<Worker> logger, ICopyService copyService, IArchiveService archiveService, ILoggingService loggingService)
    {
        _logger = logger;
        _loggingService = loggingService;
        _copyService = copyService;
        _archiveService = archiveService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
       // _loggingService.ToLog();
        string toArchive = await  _copyService.ToCopy();
        _archiveService.ToArchive(toArchive);
    }
}