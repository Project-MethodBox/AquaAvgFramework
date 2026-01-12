using AquaAvgFramework.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Switch;

public class MaskWipeSwitch : IAnimation
{
    public int DurationMillisecond { get; set; }

    public MaskWipeSwitch(int durationMillisecond)
    {
        DurationMillisecond = durationMillisecond;
    }

    public MaskWipeSwitch() { }

    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        var gamePanel = (GamePanel)parentElement;
        var nowImage = gamePanel.BackImage;
        var newImageSource = ((Image)sonElement).Source;

        gamePanel.AnimationImage.Source = newImageSource;
        gamePanel.AnimationImage.Opacity = 1;
        gamePanel.AnimationImage.Margin = new Thickness(0);

        double width = parentElement.ActualWidth;
        double height = parentElement.ActualHeight;

        if (width <= 0) width = 1920;
        if (height <= 0) height = 1080;

        var startRect = new Rect(0, 0, 0, height);
        var endRect = new Rect(0, 0, width, height);

        var clipRect = new RectangleGeometry(startRect);
        gamePanel.AnimationImage.Clip = clipRect;

        var rectAnimation = new RectAnimation(
            startRect,
            endRect,
            TimeSpan.FromMilliseconds(DurationMillisecond)
        )
        {
            EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
        };

        var sb = new Storyboard();
        Storyboard.SetTarget(rectAnimation, gamePanel.AnimationImage);
        Storyboard.SetTargetProperty(rectAnimation, new PropertyPath("Clip.Rect"));

        sb.Children.Add(rectAnimation);

        sb.Completed += (s, e) =>
        {
            nowImage.Source = newImageSource;
            gamePanel.AnimationImage.Opacity = 0;
            gamePanel.AnimationImage.Clip = null;
        };

        sb.Begin();
    }
}