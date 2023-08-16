namespace CopyAppWorker.Logging.Interfaces;

public interface ILoggingService
{
    public void ToLog(string log, LogTypes logType);

    public void InfoLog(string log);

    public void DebugLog(string log);

    public void ErrorLog(string log);

}