using CopyAppWorker.Archive.interfaces;
using CopyAppWorker.Copy.Interfaces;
using CopyAppWorker.Copy.Services;

namespace CopyAppWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ICopyService _copyService;
    private readonly IArchiveService _archiveService;

    public Worker(ILogger<Worker> logger, ICopyService copyService, IArchiveService archiveService)
    {
        _logger = logger;
        _copyService = copyService;
        _archiveService = archiveService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string toArchive = await  _copyService.ToCopy();
        _archiveService.ToArchive(toArchive);
    }
}