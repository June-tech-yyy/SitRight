using System;
using System.IO;
using System.Text.Json;
using SitRight.DataTypes;

namespace SitRight.Services;

/// <summary>
/// 配置服务 - 负责 JSON 文件的读写
/// </summary>
public class ConfigService
{
    private readonly string _configPath;
    private AppConfig? _cachedConfig;

    public ConfigService(string? configPath = null)
    {
        _configPath = configPath ?? Path.Combine(Directory.GetCurrentDirectory(), "config.json");
    }

    public AppConfig Load()
    {
        if (_cachedConfig != null) return _cachedConfig;

        if (File.Exists(_configPath))
        {
            var json = File.ReadAllText(_configPath);
            _cachedConfig = JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
        }
        else
        {
            _cachedConfig = new AppConfig();
            Save(_cachedConfig);
        }

        return _cachedConfig;
    }

    public void Save(AppConfig config)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(config, options);
        File.WriteAllText(_configPath, json);
        _cachedConfig = config;
    }
}