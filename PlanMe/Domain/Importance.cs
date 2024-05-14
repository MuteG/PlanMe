namespace PlanMe.Domain;

/// <summary>
/// 重要度
/// </summary>
public enum Importance
{
    /// <summary>
    /// 普通
    /// </summary>
    Normal = 0,
    /// <summary>
    /// 稍弱
    /// </summary>
    Less = -1,
    /// <summary>
    /// 较强
    /// </summary>
    Very = 1
}