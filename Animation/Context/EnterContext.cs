namespace AquaAvgFramework.Animation.Context;

/// <summary>
/// The content included at the beginning of animation execution
/// </summary>
/// <param name="enterAnimations"></param>
public class EnterContext(List<IAnimation> enterAnimations)
{
    /// <summary>
    /// The animation executed when the element enters
    /// </summary>
    public List<IAnimation> EnterAnimations { get; set; } = enterAnimations;
}