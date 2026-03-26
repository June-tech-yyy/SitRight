using SitRight.DataTypes;

namespace SitRight.Services;

public class ValueMapper
{
    private readonly int _hintStartLevel;
    private readonly int _urgentLevel;

    // 构造函数：接收配置参数
    public ValueMapper(int hintStartLevel, int urgentLevel)
    {
        _hintStartLevel = hintStartLevel;
        _urgentLevel = urgentLevel;
    }

    // 核心映射方法：将 0-100 的数值转换为 OverlayState 枚举
    public OverlayState Map(int rawValue)
    {
        // 调用 OverlayStateExtensions 静态类中的方法
        // 注意：这里必须使用 OverlayStateExtensions，而不是 OverlayState
        return OverlayStateExtensions.FromDisplayLevel(rawValue, _hintStartLevel, _urgentLevel);
    }
}