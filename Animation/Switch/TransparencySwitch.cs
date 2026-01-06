using AquaAvgFramework.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Switch;

/// <summary>
/// Provide the effect of image switching through transparency changes
/// </summary>
public class TransparencySwitch : IAnimation
{
    /// <summary>
    /// The time elapsed for a complete change in transparency to occur
    /// </summary>
    public int DurationMillisecond { get; set; }

    public TransparencySwitch(int durationMillisecond)
    {
        DurationMillisecond= durationMillisecond;
    }

    public TransparencySwitch() { }

    /// <summary>
    /// Realize a similar cross stacking effect on background images
    /// </summary>
    /// <param name="parentElement"><code>GamePanel</code>object</param>
    /// <param name="sonElement">A new image created as an <code>Image</code> object</param>
    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        var gamePanel = (GamePanel)parentElement;
        var nowImage = gamePanel.BackImage;

        var newImageSource = ((Image)sonElement).Source;
        gamePanel.AnimationImage.Source = newImageSource;

        // Apply animation
        var tempName = $"ta{Random.Shared.Next(10000000, 99999999)}";
        gamePanel.RegisterName(tempName, gamePanel.AnimationImage);
        var transparencyAnimation = new DoubleAnimation()
        {
            From = 0d,
            To = 1d,
            AutoReverse = false,
            Duration = TimeSpan.FromMilliseconds(DurationMillisecond)
        };

        // Create animation
        var storyBoard = new Storyboard();
        storyBoard.Children.Add(transparencyAnimation);
        Storyboard.SetTargetName(transparencyAnimation, tempName);
        Storyboard.SetTargetProperty(transparencyAnimation,
            new(UIElement.OpacityProperty));
        storyBoard.Begin(gamePanel.AnimationImage);

        // Linkage animation
        var tempLinkageName = "";
        tempLinkageName = $"ta{Random.Shared.Next(10000000, 99999999)}";
        gamePanel.RegisterName(tempLinkageName, gamePanel.BackImage);
        var linkageAnimation = new DoubleAnimation()
        {
            From = 1d,
            To = 0d,
            AutoReverse = false,
            Duration = TimeSpan.FromMilliseconds(DurationMillisecond)
        };

        var linkageBoard = new Storyboard();
        linkageBoard.Children.Add(linkageAnimation);
        Storyboard.SetTargetName(linkageAnimation, tempLinkageName);
        Storyboard.SetTargetProperty(linkageAnimation,
            new(UIElement.OpacityProperty));
        linkageBoard.Begin(gamePanel.BackImage);

        // Restore
        Task.Run(() =>
        {
            Thread.Sleep(DurationMillisecond + 500);
            nowImage.Dispatcher.Invoke(() =>
            {
                nowImage.Source = newImageSource;
                nowImage.Opacity = 0d;
                parentElement.UnregisterName(tempName);
                parentElement.UnregisterName(tempLinkageName);
            });
        });
    }
}