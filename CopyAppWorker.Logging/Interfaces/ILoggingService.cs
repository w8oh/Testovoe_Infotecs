namespace CopyAppWorker.Logging.Interfaces;

public interface ILoggingService
{
    public void ToLog(string log, LogTypes logType);
    
}