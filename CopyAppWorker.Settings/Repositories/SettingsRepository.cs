using System.Text.Json;
using CopyAppWorker.Settings.Interfaces;
using CopyAppWorker.Settings.Models;

namespace CopyAppWorker.Settings.Repositories;

public class SettingsRepository : ISettingsRepository
{
    public async Task<SettingsModel> GetSettings()
    {
        // чтение данных
        await using (FileStream fs = new FileStream("settings.json", FileMode.OpenOrCreate)) {
            SettingsModel? settings = await JsonSerializer.DeserializeAsync<SettingsModel>(fs);
            return settings;
        }
    }
}