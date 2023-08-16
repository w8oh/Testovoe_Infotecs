using CopyAppWorker.Copy.Interfaces;
using CopyAppWorker.Logging.Interfaces;
using CopyAppWorker.Settings.Interfaces;
using CopyAppWorker.Settings.Models;

namespace CopyAppWorker.Copy.Services;

public class CopyService : ICopyService
{
    private readonly ISettingsService _settingsService;
    private readonly ILoggingService _loggingService;

    public CopyService(ISettingsService settingsService, ILoggingService loggingService)
    {
        _settingsService = settingsService;
        _loggingService = loggingService;
    }

    public async Task<String> ToCopy()
    {
        _loggingService.InfoLog("Copy started");
        SettingsModel settings = await _settingsService.GetSettings();
        string[] pathFrom = settings.PathFrom;

        string newPathTo = settings.PathTo + @"\" + DateTime.Now.ToString("dd.MM.yy HH-mm-ss");

        if (!Directory.Exists(newPathTo)) {
            Directory.CreateDirectory(newPathTo);
            _loggingService.DebugLog("Directory created: " + newPathTo);
        }

        foreach (string currentPathFrom in pathFrom) {
            try {
                foreach (string dirPath in Directory.GetDirectories(currentPathFrom, "*", SearchOption.AllDirectories)) {
                    Directory.CreateDirectory(dirPath.Replace(currentPathFrom, newPathTo));
                    _loggingService.DebugLog("Directory created: " + dirPath);
                }

                foreach (string type in settings.FileTypes) {
                    foreach (string newPath in Directory.GetFiles(currentPathFrom, type, SearchOption.AllDirectories)) {
                        File.Copy(newPath, newPath.Replace(currentPathFrom, newPathTo), true);
                        _loggingService.DebugLog("File copied: " + newPath);
                    }
                }
            } catch (DirectoryNotFoundException dirNotFound) {
                _loggingService.ErrorLog("Directory not found: " + dirNotFound.Message);
            } catch (UnauthorizedAccessException unAuth) {
                _loggingService.ErrorLog("Unauthorized access: " + unAuth.Message);
            } catch (IOException io) {
                _loggingService.ErrorLog("IO error: " + io.Message);
            } catch (Exception e) {
                _loggingService.ErrorLog("Error: " + e.Message);
            }
        }

        _loggingService.InfoLog("Copy finished");

        return newPathTo;
    }
}