using System.Windows;

namespace AquaAvgFramework.Animation.Switch;

/// <summary>
/// Provide the effect of image switching through transparency changes
/// </summary>
public class TransparencySwitch(int durationMillisecond) : IAnimation
{
    public int DurationMillisecond { get; set; } = durationMillisecond;

    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        throw new NotImplementedException();
    }
}

