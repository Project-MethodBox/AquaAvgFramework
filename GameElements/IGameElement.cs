using AquaAvgFramework.Animation;
using AquaAvgFramework.Controls;
using System.Windows.Media;

namespace AquaAvgFramework.GameElements
{
    public interface IGameElement
    {
        public int ElementId { get; set; }
        public void Enter(GamePanel gamePanel);
    }

    public interface IBlocking : IAnimationExecutable;
}