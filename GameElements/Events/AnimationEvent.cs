using System.Windows;
using AquaAvgFramework.Animation;
using AquaAvgFramework.Controls;
using AquaAvgFramework.Global;

namespace AquaAvgFramework.GameElements.Events
{
    public class AnimationEvent(
        IAnimation elementAnimation,
        int elementId,
        FrameworkElement gameElement,
        SonContainer gameElementParent)
        : IGameElement
    {
        public int ElementId { get; set; } = elementId;
        public SonContainer GameElementParent { get; set; } = gameElementParent;
        public FrameworkElement GameElement { get; set; } = gameElement;
        public IAnimation ElementAnimation { get; set; } = elementAnimation;

        public void Enter(GamePanel gamePanel)
        {
            var container = GameElementParent == SonContainer.MainGrid ? gamePanel.MainGrid : gamePanel.CenterGrid;
            ElementAnimation.ExecuteAnimation(container, GameElement);
        }
    }
}
