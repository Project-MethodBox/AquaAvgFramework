using System.Windows;
using AquaAvgFramework.Animation;
using AquaAvgFramework.Controls;
using AquaAvgFramework.Global;

namespace AquaAvgFramework.GameElements.Events
{
    public class AnimationEvent : IGameElement
    {
        public int ElementId { get; set; }
        public SonContainer GameElementParent { get; set; }
        public FrameworkElement GameElement { get; set; }
        public IAnimation ElementAnimation { get; set; }

        public AnimationEvent(
            IAnimation elementAnimation,
            int elementId,
            FrameworkElement gameElement,
            SonContainer gameElementParent)
        {
            ElementId= elementId;
            GameElementParent= gameElementParent;
            GameElement= gameElement;
            ElementAnimation= elementAnimation;
        }

        public AnimationEvent() { }

        public void Enter(GamePanel gamePanel)
        {
            var container = GameElementParent == SonContainer.MainGrid ? gamePanel.MainGrid : gamePanel.CenterGrid;
            ElementAnimation.ExecuteAnimation(container, GameElement);
        }
    }
}
