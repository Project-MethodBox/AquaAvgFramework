namespace AquaAvgFramework.Animation.Context;

/// <summary>
/// The content included at the beginning of animation execution
/// </summary>
public class EnterContext
{
    /// <summary>
    /// The animation executed when the element enters
    /// </summary>
    public List<IAnimation> EnterAnimations { get; set; }

    /// <param name="enterAnimations"></param>
    public EnterContext(List<IAnimation> enterAnimations)
    {
        EnterAnimations= enterAnimations;
    }

    public EnterContext() { }
}