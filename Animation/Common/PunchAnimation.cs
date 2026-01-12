using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Common;

public class PunchAnimation : IAnimation
{
    public int DurationMillisecond { get; set; } = 300;
    public double ScaleFactor { get; set; } = 1.1;

    public PunchAnimation(int durationMillisecond, double scaleFactor = 1.1)
    {
        DurationMillisecond = durationMillisecond;
        ScaleFactor = scaleFactor;
    }

    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        sonElement.RenderTransformOrigin = new Point(0.5, 0.5);
        var st = new ScaleTransform(1, 1);
        sonElement.RenderTransform = st;

        var punchAnim = new DoubleAnimationUsingKeyFrames();
        punchAnim.KeyFrames.Add(new EasingDoubleKeyFrame(ScaleFactor,
            KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(DurationMillisecond * 0.3))));
        punchAnim.KeyFrames.Add(new EasingDoubleKeyFrame(1.0,
            KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(DurationMillisecond))));

        st.BeginAnimation(ScaleTransform.ScaleXProperty, punchAnim);
        st.BeginAnimation(ScaleTransform.ScaleYProperty, punchAnim);
    }
}