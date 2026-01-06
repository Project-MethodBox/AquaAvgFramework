using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Common;

/// <summary>
/// Animation that enables element movement
/// </summary>
public class MoveAnimation : AquaAvgFramework.Animation.IAnimation
{
    [JsonPropertyName("ms")]
    public int DurationMillisecond { get; set; }

    /// <summary>
    /// Starting coordinates of movement
    /// </summary>
    [JsonPropertyName("start")]
    public (int, int)? StartPosition { get; set; }

    /// <summary>
    /// Ending coordinates of movement
    /// </summary>
    [JsonPropertyName("end")]
    public (int, int) EndPosition { get; set; }

    /// <param name="durationMillisecond"></param>
    /// <param name="endPosition"></param>
    /// <param name="startPosition"></param>
    public MoveAnimation(int durationMillisecond, (int, int) endPosition, (int, int)? startPosition)
    {
        DurationMillisecond= durationMillisecond;
        StartPosition= startPosition;
        EndPosition= endPosition;
    }

    public MoveAnimation() { }

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