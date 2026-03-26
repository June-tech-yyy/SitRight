namespace SitRight.DataTypes;

/// <summary>
/// 应用配置模型 - 对应 JSON 配置文件结构
/// </summary>
public class AppConfig
{
    public string DefaultComPort { get; set; } = "COM1";
    public int BaudRate { get; set; } = 115200;
    public int TimeoutThresholdMs { get; set; } = 2000;
    public int DisplayRefreshIntervalMs { get; set; } = 33;
    public double SmoothingAlpha { get; set; } = 0.18; // 平滑系数
    public double MaxMaskOpacity { get; set; } = 0.70;
    public int HintStartLevel { get; set; } = 30;     // 提示阈值
    public int UrgentLevel { get; set; } = 80;        // 紧急阈值
}