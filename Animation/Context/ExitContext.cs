namespace AquaAvgFramework.Animation.Context;

/// <summary>
/// The animation content executed when the element exits
/// </summary>
public class ExitContext(List<IAnimation> exitAnimations, int exitElementId = 0, int exitStoryLineId = 0)
{
    /// <summary>
    /// The animation executed when the element exits
    /// </summary>
    public List<IAnimation> ExitAnimations { get; set; } = exitAnimations;
    public int ExitElementId { get; set; } = exitElementId;
    public int ExitStoryLineId { get; set; } = exitStoryLineId;
}