using System;
using System.Threading;
using SitRight.DataTypes;
using SitRight.Services;

namespace SitRight;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== 坐姿矫正仪系统启动 ===");

        // 1. 加载配置
        var configService = new ConfigService();
        var config = configService.Load();

        // 2. 初始化控制器 (传入 4 个具体参数)
        // 对应 BlurController 的 4 参数构造函数
        var blurController = new BlurController(
            config.SmoothingAlpha, 
            config.HintStartLevel, 
            config.UrgentLevel, 
            config.MaxMaskOpacity
        );

        var random = new Random();
        Console.WriteLine("开始模拟数据... 按 'q' 退出");

        while (true)
        {
            if (Console.KeyAvailable && Console.ReadKey(true).KeyChar == 'q') break;

            // 模拟姿态等级 (0-100)
            int simulatedLevel = random.Next(0, 100);

            // 更新控制器
            blurController.Update(simulatedLevel);
            double opacity = blurController.GetCurrentOpacity();

            // 获取状态 (使用扩展方法)
            var state = OverlayStateExtensions.FromDisplayLevel(
                simulatedLevel, 
                config.HintStartLevel, 
                config.UrgentLevel
            );

            Console.WriteLine($"等级: {simulatedLevel,3} | 状态: {state,6} | 模糊度: {opacity:F2}");
            
            Thread.Sleep(500);
        }
    }
}