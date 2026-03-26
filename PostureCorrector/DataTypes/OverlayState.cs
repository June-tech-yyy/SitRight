namespace SitRight.DataTypes;

public enum OverlayState
{
    Normal,     // 正常
    Hint,       // 提示
    Urgent      // 紧急
}

public static class OverlayStateExtensions
{
    // 根据等级数值返回对应的状态枚举
    public static OverlayState FromDisplayLevel(int level, int hintThreshold, int urgentThreshold)
    {
        if (level >= urgentThreshold) return OverlayState.Urgent;
        if (level >= hintThreshold) return OverlayState.Hint;
        return OverlayState.Normal;
    }
}