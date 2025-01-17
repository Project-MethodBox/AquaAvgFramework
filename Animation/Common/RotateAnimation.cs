using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AquaAvgFramework.Animation.Common
{
    public class RotateAnimation((int, int)? center, int durationMillisecond, int endAngle, int startAngle)
        : IAnimation
    {
        public int DurationMillisecond { get; set; } = durationMillisecond;
        public int? StartAngle { get; set; } = startAngle;
        public int EndAngle { get; set; } = endAngle;
        public (int, int)? Center { get; set; } = center;

        public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement)
        {
            var sonName = "_" + DateTime.Now.GetHashCode().ToString().Replace("-", "");
            parentElement.RegisterName(sonName, sonElement);
            Center ??= ((int)sonElement.Width / 2, (int)sonElement.Height / 2);

            TransformGroup transformGroup;
            try
            {
                transformGroup = sonElement.RenderTransform is null ?
                   new TransformGroup() :
                   (TransformGroup)sonElement.RenderTransform;
            }
            catch (InvalidCastException)
            {
                transformGroup = new TransformGroup();
            }

            var rotateTransform = new RotateTransform();
            transformGroup.Children.Add(rotateTransform);
            sonElement.RenderTransform = transformGroup;

            var length = transformGroup.Children.Count;

            var rotateAnimation = new DoubleAnimation
            {
                From = StartAngle,
                To = EndAngle,
                Duration = TimeSpan.FromMilliseconds(DurationMillisecond),
                AutoReverse = false
            };

            // Create animation
            var storyBoard = new Storyboard();
            storyBoard.Children.Add(rotateAnimation);
            Storyboard.SetTargetName(rotateAnimation, sonName);
            Storyboard.SetTargetProperty(rotateAnimation,
                new($"(UIElement.RenderTransform).(TransformGroup." +
                    $"Children)[{length - 1}].(RotateTransform.Angle)"));
            storyBoard.Begin(parentElement);

            parentElement.UnregisterName(sonName);
        }
    }
}