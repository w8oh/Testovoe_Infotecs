using CopyAppWorker.Settings.Interfaces;
using CopyAppWorker.Settings.Models;

namespace CopyAppWorker.Settings.Services;

public class SettingsService : ISettingsService
{
    private readonly ISettingsRepository _settingsRepository;

    public SettingsService(ISettingsRepository settingsRepository)
    {
        _settingsRepository = settingsRepository;
    }

    public async Task<SettingsModel> GetSettings()
    {
        return await _settingsRepository.GetSettings();
    }
}