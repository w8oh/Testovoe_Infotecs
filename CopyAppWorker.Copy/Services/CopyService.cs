using CopyAppWorker.Copy.Interfaces;
using CopyAppWorker.Settings.Interfaces;
using CopyAppWorker.Settings.Models;

namespace CopyAppWorker.Copy.Services;

public class CopyService : ICopyService
{
    private readonly ISettingsService _settingsService;

    public CopyService(ISettingsService settingsService)
    {
        _settingsService = settingsService; 
    }

    public async Task<String> ToCopy() 
    {
        
        SettingsModel settings = await _settingsService.GetSettings();
        string[] pathFrom = settings.PathFrom;

        string newPathTo = settings.PathTo + "/" + DateTime.Now.ToString("dd.MM.yy HH-mm-ss");
        
        if (!Directory.Exists(newPathTo))
        {
            Directory.CreateDirectory(newPathTo);
        }

        foreach (string currentPathFrom in pathFrom) {
            try 
            {
                foreach (string dirPath in Directory.GetDirectories(currentPathFrom, "*", SearchOption.AllDirectories)) {
                    Directory.CreateDirectory(dirPath.Replace(currentPathFrom, newPathTo));
                }

                foreach (string type in settings.FileTypes) {
                    foreach (string newPath in Directory.GetFiles(currentPathFrom, type, SearchOption.AllDirectories)) {
                        File.Copy(newPath, newPath.Replace(currentPathFrom, newPathTo), true);
                    }
                }
            } 
            catch (DirectoryNotFoundException dirNotFound) {
                Console.WriteLine(dirNotFound.Message);
            } 
            catch (UnauthorizedAccessException unAuth) {
                Console.WriteLine(unAuth.Message);
            }
            catch (IOException io) {
                Console.WriteLine(io.Message);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
     
        
        return newPathTo;
    } 
}