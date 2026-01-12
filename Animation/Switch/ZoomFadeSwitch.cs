using AquaAvgFramework.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Switch;

public class ZoomFadeSwitch : IAnimation
{
    public int DurationMillisecond { get; set; }

    public ZoomFadeSwitch(int durationMillisecond)
    {
        DurationMillisecond = durationMillisecond;
    }

    public ZoomFadeSwitch() { }

    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        var gamePanel = (GamePanel)parentElement;
        var nowImage = gamePanel.BackImage;
        var newImageSource = ((Image)sonElement).Source;

        gamePanel.AnimationImage.Source = newImageSource;
        gamePanel.AnimationImage.Opacity = 0;
        gamePanel.AnimationImage.Margin = new Thickness(0);

        gamePanel.AnimationImage.RenderTransformOrigin = new Point(0.5, 0.5);
        nowImage.RenderTransformOrigin = new Point(0.5, 0.5);

        var nowScale = new ScaleTransform(1.0, 1.0);
        var newScale = new ScaleTransform(1.1, 1.1);
        nowImage.RenderTransform = nowScale;
        gamePanel.AnimationImage.RenderTransform = newScale;

        var duration = TimeSpan.FromMilliseconds(DurationMillisecond);
        var sb = new Storyboard();

        var oldScaleX = new DoubleAnimation(1.2, duration);
        var oldScaleY = new DoubleAnimation(1.2, duration);
        var oldOpacity = new DoubleAnimation(0, duration);
        Storyboard.SetTarget(oldScaleX, nowImage);
        Storyboard.SetTargetProperty(oldScaleX, new PropertyPath("RenderTransform.ScaleX"));
        Storyboard.SetTarget(oldScaleY, nowImage);
        Storyboard.SetTargetProperty(oldScaleY, new PropertyPath("RenderTransform.ScaleY"));
        Storyboard.SetTarget(oldOpacity, nowImage);
        Storyboard.SetTargetProperty(oldOpacity, new PropertyPath(FrameworkElement.OpacityProperty));

        var newScaleX = new DoubleAnimation(1.0, duration);
        var newScaleY = new DoubleAnimation(1.0, duration);
        var newOpacity = new DoubleAnimation(1, duration);
        Storyboard.SetTarget(newScaleX, gamePanel.AnimationImage);
        Storyboard.SetTargetProperty(newScaleX, new PropertyPath("RenderTransform.ScaleX"));
        Storyboard.SetTarget(newScaleY, gamePanel.AnimationImage);
        Storyboard.SetTargetProperty(newScaleY, new PropertyPath("RenderTransform.ScaleY"));
        Storyboard.SetTarget(newOpacity, gamePanel.AnimationImage);
        Storyboard.SetTargetProperty(newOpacity, new PropertyPath(FrameworkElement.OpacityProperty));

        sb.Children.Add(oldScaleX); sb.Children.Add(oldScaleY); sb.Children.Add(oldOpacity);
        sb.Children.Add(newScaleX); sb.Children.Add(newScaleY); sb.Children.Add(newOpacity);

        sb.Completed += (s, e) =>
        {
            nowImage.Source = newImageSource;
            nowImage.Opacity = 1;
            nowImage.RenderTransform = null;
            gamePanel.AnimationImage.Opacity = 0;
            gamePanel.AnimationImage.RenderTransform = null;
        };

        sb.Begin();
    }
}