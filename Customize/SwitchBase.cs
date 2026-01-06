using System.Windows;
using AquaAvgFramework.Animation;

namespace AquaAvgFramework.Customize;

/// <summary>
/// Provide customization for switching animations
/// If you want to implement customization, override the <code>ExecuteAnimation</code> method
/// </summary>
public class SwitchBase : IAnimation
{
    /// <summary>
    /// The time elapsed for a complete change in transparency to occur
    /// </summary>
    public int DurationMillisecond { get; set; }

    /// <summary>
    /// Indicates whether to execute another animation on the existing
    /// image when entering the animation for the current image
    /// </summary>
    public bool Linkage { get; set; }

    /// <summary>
    /// When switching between images, the animation within this method will be executed.
    /// Firstly, the parentElement should be converted to a GamePanel instance, and then its BackImage object should be obtained, which represents its original image.
    /// Afterward, if necessary, you can define the animation for the object to exit.
    /// Secondly, sonElement represents a new image, and its Source property should be obtained and assigned to the AnimationImage of the GamePanel object, which represents the new image.
    /// Next, apply the animation to it.
    /// The final step is to convert the original image into a new image and restore it.
    /// </summary>
    /// <param name="parentElement"><code>GamePanel</code>object</param>
    /// <param name="sonElement">A new image created as an <code>Image</code> object</param>
    /// <exception cref="NotImplementedException">Method not overloaded</exception>
    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        throw new NotImplementedException();
    }

    public SwitchBase() { }
}