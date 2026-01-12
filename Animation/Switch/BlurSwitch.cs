using AquaAvgFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace AquaAvgFramework.Animation.Switch
{
    public class BlurSwitch : IAnimation
    {
        public BlurSwitch(int durationMillisecond, double maxBlurRadius = 20)
        {
            DurationMillisecond = durationMillisecond;
            MaxBlurRadius = maxBlurRadius;
        }

        public BlurSwitch() { }

        public int DurationMillisecond { get; set; } = 500;

        public double MaxBlurRadius { get; set; } = 20;

        public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
        {
            var gamePanel = (GamePanel)parentElement;
            var nowImage = gamePanel.BackImage;
            var newImageSource = ((System.Windows.Controls.Image)sonElement).Source;

            gamePanel.AnimationImage.Source = newImageSource;
            gamePanel.AnimationImage.Opacity = 0;
            gamePanel.AnimationImage.Margin = new Thickness(0);

            var oldBlur = new BlurEffect { Radius = 0 };
            var newBlur = new BlurEffect { Radius = MaxBlurRadius };
            nowImage.Effect = oldBlur;
            gamePanel.AnimationImage.Effect = newBlur;

            var duration = TimeSpan.FromMilliseconds(DurationMillisecond);
            var storyboard = new Storyboard();

            var oldBlurAnim = new DoubleAnimation(MaxBlurRadius, duration);
            var oldOpacityAnim = new DoubleAnimation(0, duration);
            Storyboard.SetTarget(oldBlurAnim, nowImage);
            Storyboard.SetTargetProperty(oldBlurAnim, new PropertyPath("Effect.Radius"));
            Storyboard.SetTarget(oldOpacityAnim, nowImage);
            Storyboard.SetTargetProperty(oldOpacityAnim, new PropertyPath(FrameworkElement.OpacityProperty));

            var newBlurAnim = new DoubleAnimation(0, duration);
            var newOpacityAnim = new DoubleAnimation(1, duration);
            Storyboard.SetTarget(newBlurAnim, gamePanel.AnimationImage);
            Storyboard.SetTargetProperty(newBlurAnim, new PropertyPath("Effect.Radius"));
            Storyboard.SetTarget(newOpacityAnim, gamePanel.AnimationImage);
            Storyboard.SetTargetProperty(newOpacityAnim, new PropertyPath(FrameworkElement.OpacityProperty));

            storyboard.Children.Add(oldBlurAnim);
            storyboard.Children.Add(oldOpacityAnim);
            storyboard.Children.Add(newBlurAnim);
            storyboard.Children.Add(newOpacityAnim);

            storyboard.Completed += (s, e) =>
            {
                nowImage.Source = newImageSource;
                nowImage.Opacity = 1;
                nowImage.Effect = null;

                gamePanel.AnimationImage.Opacity = 0;
                gamePanel.AnimationImage.Effect = null;
            };

            storyboard.Begin();
        }
    }
}
