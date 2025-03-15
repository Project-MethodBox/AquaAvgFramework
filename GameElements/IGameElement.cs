using AquaAvgFramework.Animation;
using AquaAvgFramework.Controls;

namespace AquaAvgFramework.GameElements
{
    public interface IGameElement
    {
        /// <summary>
        /// The ID of current element
        /// </summary>
        public int ElementId { get; set; }

        /// <summary>
        /// The event when the object was set off
        /// </summary>
        /// <param name="gamePanel"></param>
        public void Enter(GamePanel gamePanel);
    }

    public interface IBlocking : IAnimationExecutable;
}