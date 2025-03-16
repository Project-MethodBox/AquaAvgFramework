using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Common;

/// <summary>
/// Animation that enables element movement
/// </summary>
/// <param name="durationMillisecond"></param>
/// <param name="endPosition"></param>
/// <param name="startPosition"></param>
public class MoveAnimation(int durationMillisecond, (int, int) endPosition, (int, int)? startPosition)
    : AquaAvgFramework.Animation.IAnimation
{
    [JsonPropertyName("ms")]
    public int DurationMillisecond { get; set; } = durationMillisecond;

    /// <summary>
    /// Starting coordinates of movement
    /// </summary>
    [JsonPropertyName("start")]
    public (int, int)? StartPosition { get; set; } = startPosition;

    /// <summary>
    /// Ending coordinates of movement
    /// </summary>
    [JsonPropertyName("end")]
    public (int, int) EndPosition { get; set; } = endPosition;

    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        var sonName = "_" + DateTime.Now.GetHashCode().ToString().Replace("-", "");
        parentElement.RegisterName(sonName, sonElement);

        StartPosition ??= ((int)parentElement.Margin.Left, (int)parentElement.Margin.Top);

        var startPosition = new Thickness(StartPosition.Value.Item1, StartPosition.Value.Item2, 0, 0);
        var endPosition = new Thickness(EndPosition.Item1, EndPosition.Item2, 0, 0);

        var moveAnimation =
            new ThicknessAnimation(startPosition, endPosition, TimeSpan.FromMilliseconds(DurationMillisecond))
            {
                AutoReverse = false
            };

        // Create animation
        var storyBoard = new Storyboard();
        storyBoard.Children.Add(moveAnimation);
        Storyboard.SetTargetName(moveAnimation, sonName);
        Storyboard.SetTargetProperty(moveAnimation,
            new(FrameworkElement.MarginProperty));
        storyBoard.Begin(parentElement);

        parentElement.UnregisterName(sonName);
    }
}