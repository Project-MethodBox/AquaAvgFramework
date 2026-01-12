using AquaAvgFramework.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Switch;

/// <summary>
/// Provide content for switching background images using sliding motion effects
/// </summary>
public class SlideSwitch : IAnimation
{
    private readonly bool linkage;

    public SlideSwitch(int durationMillisecond, bool linkage = false)
    {
        this.linkage=linkage;
        DurationMillisecond= durationMillisecond;
    }

    public SlideSwitch() { }

    /// <summary>
    /// Time elapsed for switching between two images
    /// </summary>
    public int DurationMillisecond { get; set; }

    /// <summary>
    /// Perform image switching action
    /// </summary>
    /// <param name="parentElement"><code>GamePanel</code>object</param>
    /// <param name="sonElement">A new image created as an <code>Image</code> object</param>
    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        var gamePanel = (GamePanel)parentElement;
        var nowImage = gamePanel.BackImage;

        // Although there is a hint of taking off pants and farting here,
        // the interface is indeed abstracted in this way
        var newImageSource = ((Image)sonElement).Source;
        gamePanel.AnimationImage.Source = newImageSource;
        gamePanel.AnimationImage.Margin = new Thickness(parentElement.ActualWidth, 0, 0, 0);

        // Apply animation
        var tempName = $"ta{Random.Shared.Next(10000000, 99999999)}";
        gamePanel.RegisterName(tempName, gamePanel.AnimationImage);
        var startPosition = gamePanel.AnimationImage.Margin;
        var endPosition = new Thickness(0);
        var moveAnimation =
            new ThicknessAnimation(startPosition, endPosition, TimeSpan.FromMilliseconds(DurationMillisecond))
            {
                AutoReverse = false
            };

        // Create animation
        var storyBoard = new Storyboard();
        storyBoard.Children.Add(moveAnimation);
        Storyboard.SetTargetName(moveAnimation, tempName);
        Storyboard.SetTargetProperty(moveAnimation,
            new(FrameworkElement.MarginProperty));
        storyBoard.Begin(gamePanel.AnimationImage);

        // Linkage animation
        var tempLinkageName = "";
        if (linkage)
        { 
            tempLinkageName = $"ta{Random.Shared.Next(10000000, 99999999)}";
            gamePanel.RegisterName(tempLinkageName, gamePanel.BackImage);
            var linkageAnimation =
                new ThicknessAnimation(new Thickness(0), new Thickness(-1200, 0, 0, 0), TimeSpan.FromMilliseconds(DurationMillisecond))
                {
                    AutoReverse = false
                };
            var linkageBoard = new Storyboard();
            linkageBoard.Children.Add(linkageAnimation);
            Storyboard.SetTargetName(linkageAnimation, tempLinkageName);
            Storyboard.SetTargetProperty(linkageAnimation,
                new(FrameworkElement.MarginProperty));
            linkageBoard.Begin(gamePanel.BackImage);
        }

        // Restore
        Task.Run(() =>
        {
            Thread.Sleep(DurationMillisecond + 300);
            nowImage.Dispatcher.Invoke(() =>
            {
                nowImage.Source = newImageSource;
                nowImage.Margin = gamePanel.AnimationImage.Margin;
                parentElement.UnregisterName(tempName);
                if (linkage) parentElement.UnregisterName(tempLinkageName);
            });

        });
    }
}