using AquaAvgFramework.Controls;
using AquaAvgFramework.Global;

namespace AquaAvgFramework.GameElements.Events
{
    public class SwitchContextEvent(
        Predicate<int> condition,
        int elementId,
        IGameElement falseNextElement,
        IGameElement trueNextElement,
        string valueName)
        : IGameElement
    {
        public int ElementId { get; set; } = elementId;
        public IGameElement TrueNextElement { get; set; } = trueNextElement;
        public IGameElement FalseNextElement { get; set; } = falseNextElement;
        public string ValueName { get; set; } = valueName;
        public Predicate<int> Condition { get; set; } = condition ?? throw new 
            ArgumentNullException(nameof(condition));

        public void Enter(GamePanel _) { }

        public IGameElement GetResult()
        {
            var num = ValueManager.Shared.GetValue(ValueName);
            return Condition(num) ? TrueNextElement : FalseNextElement;
        }
    }
}
