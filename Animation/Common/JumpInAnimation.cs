using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Common;

public class JumpInAnimation : IAnimation
{
    public int DurationMillisecond { get; set; } = 800;

    public JumpInAnimation(int durationMillisecond)
    {
        DurationMillisecond = durationMillisecond;
    }

    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {

        var originalMargin = sonElement.Margin;
        var startMargin = new Thickness(originalMargin.Left, originalMargin.Top + 200, 0, 0);

        sonElement.Margin = startMargin;
        sonElement.Opacity = 0;

        var moveAnim = new ThicknessAnimation(startMargin, originalMargin, TimeSpan.FromMilliseconds(DurationMillisecond))
        {
            EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 4 }
        };

        var opacityAnim = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(DurationMillisecond / 2));

        sonElement.BeginAnimation(FrameworkElement.MarginProperty, moveAnim);
        sonElement.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
    }
}
