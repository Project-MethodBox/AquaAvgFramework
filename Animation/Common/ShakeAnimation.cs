using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Common;

public class ShakeAnimation : IAnimation
{
    public int DurationMillisecond { get; set; } = 400;
    public double Strength { get; set; } = 20;

    public ShakeAnimation(int durationMillisecond, double strength = 20)
    {
        DurationMillisecond = durationMillisecond;
        Strength = strength;
    }

    public ShakeAnimation() { }

    public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
    {
        var tt = new TranslateTransform();
        sonElement.RenderTransform = tt;

        var shakeAnim = new DoubleAnimationUsingKeyFrames();
        var rand = new Random();
        int frameCount = 6;

        for (int i = 0; i <= frameCount; i++)
        {
            double pos = (i == frameCount) ? 0 : (rand.NextDouble() * 2 - 1) * Strength;
            var keyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(DurationMillisecond * i / frameCount));
            shakeAnim.KeyFrames.Add(new LinearDoubleKeyFrame(pos, keyTime));
        }

        tt.BeginAnimation(TranslateTransform.XProperty, shakeAnim);
    }
}