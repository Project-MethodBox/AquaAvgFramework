using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Common;

/// <summary>
/// Animation that enables element rotation
/// </summary>
/// <param name="center">Coordinate of anchor points for rotating animation elements</param>
/// <param name="durationMillisecond">Animation execution time</param>
/// <param name="endAngle">Rotation angle at termination</param>
/// <param name="startAngle">The angle of rotation at the beginning</param>
public class RotateAnimation((int, int)? center, int durationMillisecond, int endAngle, int startAngle)
    : IAnimation
{
    public int DurationMillisecond { get; set; } = durationMillisecond;

    /// <summary>
    /// The angle of rotation at the beginning
    /// </summary>
    public int? StartAngle { get; set; } = startAngle;

    /// <summary>
    /// Rotation angle at termination
    /// </summary>
    public int EndAngle { get; set; } = endAngle;

    /// <summary>
    /// Coordinate of anchor points for rotating animation elements
    /// </summary>
    public (int, int)? Center { get; set; } = center;

    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        var sonName = "_" + DateTime.Now.GetHashCode().ToString().Replace("-", "");
        parentElement.RegisterName(sonName, sonElement);
        Center ??= ((int)sonElement.Width / 2, (int)sonElement.Height / 2);

        TransformGroup transformGroup;
        try
        {
            transformGroup = sonElement.RenderTransform is null ?
               new TransformGroup() :
               (TransformGroup)sonElement.RenderTransform;
        }
        catch (InvalidCastException)
        {
            transformGroup = new TransformGroup();
        }

        var rotateTransform = new RotateTransform();
        transformGroup.Children.Add(rotateTransform);
        sonElement.RenderTransform = transformGroup;

        var length = transformGroup.Children.Count;

        var rotateAnimation = new DoubleAnimation
        {
            From = StartAngle,
            To = EndAngle,
            Duration = TimeSpan.FromMilliseconds(DurationMillisecond),
            AutoReverse = false
        };

        // Create animation
        var storyBoard = new Storyboard();
        storyBoard.Children.Add(rotateAnimation);
        Storyboard.SetTargetName(rotateAnimation, sonName);
        Storyboard.SetTargetProperty(rotateAnimation,
            new($"(UIElement.RenderTransform).(TransformGroup." +
                $"Children)[{length - 1}].(RotateTransform.Angle)"));
        storyBoard.Begin(parentElement);

        parentElement.UnregisterName(sonName);
    }
}