using AquaAvgFramework.Animation.Common;
using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Animation.Switch;
using AquaAvgFramework.Controls;
using AquaAvgFramework.Customize;
using AquaAvgFramework.GameElements;
using System.Text.Json.Serialization;
using System.Windows;

namespace AquaAvgFramework.Animation;

/// <summary>
/// Provide a universal solution for parent-child animations
/// </summary>

[JsonDerivedType(typeof(MoveAnimation), "Move")]
[JsonDerivedType(typeof(RotateAnimation), "Rotate")]
[JsonDerivedType(typeof(SlideSwitch), "Slide")]
[JsonDerivedType(typeof(SwitchBase), "SwitchBase")]
[JsonDerivedType(typeof(TransparencySwitch), "Transparency")]
[JsonDerivedType(typeof(BlurSwitch), "Blur")]
[JsonDerivedType(typeof(ZoomFadeSwitch), "Zoom")]
[JsonDerivedType(typeof(MaskWipeSwitch), "Wipe")]
[JsonDerivedType(typeof(FloatAnimation), "Float")]
[JsonDerivedType(typeof(ShakeAnimation), "Shake")]
[JsonDerivedType(typeof(JumpInAnimation), "JumpIn")]
[JsonDerivedType(typeof(PunchAnimation), "Punch")]
public interface IAnimation
{
    /// <summary>
    /// Animation execution time
    /// </summary>
    public int DurationMillisecond { get; set; }

    /// <summary>
    /// Execute the specified animation for sonElement on parentElement
    /// </summary>
    /// <param name="parentElement">Container elements for animation execution</param>
    /// <param name="sonElement">Element for the animation being executed</param>
    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement);
}

public interface IAnimationExecutable : IGameElement
{
    /// <summary>
    /// The animation context when entering the element
    /// </summary>
    public EnterContext? EnterContext { get; set; }

    /// <summary>
    /// The animation context when exiting the element
    /// </summary>
    public ExitContext? ExitContext { get; set; }

    /// <summary>
    /// Delete the current element
    /// </summary>
    /// <param name="gamePanel"></param>
    public void RemoveFromGrid(GamePanel gamePanel);

    /// <summary>
    /// Indicates the behavior that occurs when the current element exits
    /// </summary>
    /// <param name="gamePanel"><code>GamePanel</code>实例</param>
    public void Exit(GamePanel gamePanel);
}