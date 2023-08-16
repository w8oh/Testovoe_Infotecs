using System.Text;
using CopyAppWorker.Logging.Interfaces;
using CopyAppWorker.Settings.Interfaces;
using CopyAppWorker.Settings.Models;

namespace CopyAppWorker.Logging.Services;

public class LoggingService: ILoggingService
{
    private readonly List<LogTypes> _logTypes;
    private readonly ISettingsService _settingsService;
    private string LogFilePath;

    public LoggingService(ISettingsService settingsService)
    {
        DirectoryFile();
        _settingsService = settingsService;
        var s = _settingsService.GetSettings().Result;
        List<string> logTypes = s.LogTypes.ToList();
        SelectLogTypes(logTypes);
    }
    
    public void DirectoryFile()
    {
        
        var directory = new DirectoryInfo($"{System.IO.Directory.GetCurrentDirectory()}/Logs");
        var file = new FileInfo(System.IO.Directory.GetCurrentDirectory() + "/Logs/" + DateTime.Now.ToString("dd.MM.yy HH.mm.ss") + ".txt");

        try 
        {
            if (!directory.Exists)
            {
                directory.Create();
            }

            if (!file.Exists) 
            {
                file.Create();
            }
        }
        catch ( Exception e)
        {
            Console.WriteLine("Directory or file was not created");
            throw;
        }
        
        LogFilePath = file.FullName;
    }
    
    
    private void SelectLogTypes(List<string> logTypes)
    {
        if (logTypes == null)
        {
            throw new ArgumentNullException(nameof(logTypes));
        }
       
        if (logTypes.Contains("Info"))
        {
            _logTypes.Add(LogTypes.Info);
        }
       
        if (logTypes.Contains("Debug"))
        {
            _logTypes.Add(LogTypes.Debug);
        }
       
        if (logTypes.Contains("Error"))
        {
            _logTypes.Add(LogTypes.Error);
        }
    }
    
    public void ToLog(string log, LogTypes logType)
    {
        if (!_logTypes.Contains(logType)) return;
        
        var logWriter = new StringBuilder();
        
        switch (logType)
        {
            case LogTypes.Info:
                logWriter.Append($"Info: {log}"); 
                break;
            case LogTypes.Debug:
                logWriter.Append($"Debug: {log}");
                break;
            case LogTypes.Error:
                logWriter.Append($"Error: {log}");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
        }

        if (logWriter.Length != 0)
        {
            File.AppendAllText(LogFilePath, logWriter.ToString());
        }
    }
    
    public void InfoLog(string log)
    {
        ToLog(log, LogTypes.Info);
    }
    
    public void DebugLog(string log)
    {
        ToLog(log, LogTypes.Debug);
    }
    
    public void ErrorLog(string log)
    {
        ToLog(log, LogTypes.Error);
    }
    
}