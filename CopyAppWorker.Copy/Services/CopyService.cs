using CopyAppWorker.Copy.Interfaces;
using CopyAppWorker.Settings.Interfaces;
using CopyAppWorker.Settings.Models;

namespace CopyAppWorker.Copy.Services;

public class CopyService: ICopyService
{
    private readonly ISettingsService _settingsService;

    public CopyService(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public async Task<String> ToCopy() 
    {
        
        SettingsModel paths = await _settingsService.GetSettings();
        string pathFrom = paths.PathFrom;
        
        DateTime today = DateTime.Now;

        string NewPath = paths.PathTo + "/" + today.ToString("dd.mm.yy hh-mm-ss");
        
        if (!Directory.Exists(NewPath))
        {
            Directory.CreateDirectory(NewPath);
        }

        try {
            foreach (string dirPath in Directory.GetDirectories(pathFrom, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(pathFrom, NewPath));
            }

            foreach (string newPath in Directory.GetFiles(pathFrom, "*.*",SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(pathFrom, NewPath), true);
            }
        } catch (Exception e) {
            Console.WriteLine("Unable to read file");
            throw;  
        }
        
        return NewPath;
    } 
}