using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Common;

public class FloatAnimation : IAnimation
{
    public int DurationMillisecond { get; set; } = 2000;
    public double Offset { get; set; } = 15;

    public FloatAnimation(int durationMillisecond, double offset = 15)
    {
        DurationMillisecond = durationMillisecond;
        Offset = offset;
    }

    public FloatAnimation() { }

    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        var tt = new TranslateTransform();
        sonElement.RenderTransform = tt;

        var floatAnim = new DoubleAnimation
        {
            From = 0,
            To = Offset,
            Duration = TimeSpan.FromMilliseconds(DurationMillisecond / 2),
            AutoReverse = true,
            RepeatBehavior = RepeatBehavior.Forever,
            EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
        };

        tt.BeginAnimation(TranslateTransform.YProperty, floatAnim);
    }
}