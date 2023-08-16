using CopyAppWorker;
using CopyAppWorker.Archive.Interfaces;
using CopyAppWorker.Archive.Services;
using CopyAppWorker.Copy.Interfaces;
using CopyAppWorker.Copy.Services;
using CopyAppWorker.Logging.Interfaces;
using CopyAppWorker.Logging.Services;
using CopyAppWorker.Settings.Interfaces;
using CopyAppWorker.Settings.Repositories;
using CopyAppWorker.Settings.Services;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
//настройки
builder.Services.AddSingleton<ISettingsRepository, SettingsRepository>();
builder.Services.AddSingleton<ISettingsService, SettingsService>();
//логировние
builder.Services.AddSingleton<ILoggingService, LoggingService>();
//копирование
builder.Services.AddTransient<ICopyService, CopyService>();
//архивация
builder.Services.AddTransient<IArchiveService, ArchiveService>();

IHost host = builder.Build();
host.Run();