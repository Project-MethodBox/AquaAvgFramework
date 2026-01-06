namespace AquaAvgFramework.Animation.Context;

/// <summary>
/// The animation content executed when the element exits
/// </summary>
public class ExitContext
{
    /// <summary>
    /// The animation executed when the element exits
    /// </summary>
    public List<IAnimation> ExitAnimations { get; set; }
    public int ExitElementId { get; set; }
    public int ExitStoryLineId { get; set; }

    public ExitContext(List<IAnimation> exitAnimations, int exitElementId = 0, int exitStoryLineId = 0)
    {
        ExitAnimations= exitAnimations;
        ExitElementId= exitElementId;
        ExitStoryLineId= exitStoryLineId;
    }

    public ExitContext() { }
}