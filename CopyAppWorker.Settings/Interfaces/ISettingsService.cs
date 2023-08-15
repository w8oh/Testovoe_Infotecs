using CopyAppWorker.Settings.Models;

namespace CopyAppWorker.Settings.Interfaces;

public interface ISettingsService
{
    Task<SettingsModel> GetSettings();

}