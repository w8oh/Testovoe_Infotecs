using CopyAppWorker.Settings.Models;

namespace CopyAppWorker.Settings.Interfaces;

public interface ISettingsRepository
{
    Task<SettingsModel> GetSettings();

}