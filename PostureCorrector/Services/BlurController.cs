using SitRight.DataTypes;

namespace SitRight.Services;

public class BlurController
{
    private readonly double _alpha;
    private readonly int _hintStartLevel;
    private readonly int _urgentLevel;
    private readonly double _maxOpacity;
    private double _currentOpacity = 0.0;

    // 注意：这里必须是 4 个参数，对应 Program.cs 的调用
    public BlurController(double alpha, int hintStartLevel, int urgentLevel, double maxOpacity)
    {
        _alpha = alpha;
        _hintStartLevel = hintStartLevel;
        _urgentLevel = urgentLevel;
        _maxOpacity = maxOpacity;
    }

    // 更新逻辑
    public void Update(int postureLevel)
    {
        double targetOpacity = 0.0;

        if (postureLevel >= _urgentLevel)
        {
            targetOpacity = _maxOpacity;
        }
        else if (postureLevel >= _hintStartLevel)
        {
            // 线性插值计算透明度
            double ratio = (double)(postureLevel - _hintStartLevel) / (_urgentLevel - _hintStartLevel);
            targetOpacity = ratio * _maxOpacity;
        }

        // 平滑处理
        _currentOpacity = _alpha * targetOpacity + (1 - _alpha) * _currentOpacity;
    }

    // 提供给外部获取当前状态
    public double GetCurrentOpacity()
    {
        return _currentOpacity;
    }
}