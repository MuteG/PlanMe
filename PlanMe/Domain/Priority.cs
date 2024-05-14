namespace PlanMe.Domain;

public enum Priority
{
    Normal = 0,
    /// <summary>
    /// 悠闲
    /// </summary>
    Leisurely = -1,
    /// <summary>
    /// 紧急
    /// </summary>
    Urgent = 1
}