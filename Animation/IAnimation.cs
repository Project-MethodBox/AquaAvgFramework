using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Controls;
using AquaAvgFramework.GameElements;
using System.Windows;

namespace AquaAvgFramework.Animation
{
    public interface IAnimation
    {
        public int DurationMillisecond { get; set; }

        public void ExecuteAnimation(FrameworkElement parentElement, FrameworkElement sonElement);
    }

    public interface IAnimationExecutable : IGameElement
    {
        public EnterContext? EnterContext { get; set; }
        public ExitContext? ExitContext { get; set; }
        public void RemoveFromGrid(GamePanel gamePanel);
        public void Exit(GamePanel gamePanel);
    }
}
