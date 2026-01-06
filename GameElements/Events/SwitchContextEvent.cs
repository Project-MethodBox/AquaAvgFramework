using AquaAvgFramework.Controls;
using AquaAvgFramework.Global;
using System.Text.Json.Serialization;

namespace AquaAvgFramework.GameElements.Events
{
    public class SwitchContextEvent : IGameElement
    {
        public int ElementId { get; set; }
        public IGameElement TrueNextElement { get; set; }
        public IGameElement FalseNextElement { get; set; }
        public string ValueName { get; set; }

        public string CompareOperator { get; set; } = "==";
        public int CompareThreshold { get; set; }

        [JsonIgnore]
        public Predicate<int> Condition { get; set; }

        public SwitchContextEvent(
            Predicate<int> condition,
            int elementId,
            IGameElement falseNextElement,
            IGameElement trueNextElement,
            string valueName)
        {
            ElementId= elementId;
            TrueNextElement= trueNextElement;
            FalseNextElement= falseNextElement;
            ValueName= valueName;
            Condition= condition ?? throw new
            ArgumentNullException(nameof(condition));
        }

        public SwitchContextEvent() { }

        public void Enter(GamePanel _) { }

        public IGameElement GetResult()
        {
            var num = ValueManager.Shared.GetValue(ValueName);
            Condition ??= RebuildCondition();

            return Condition(num) ? TrueNextElement : FalseNextElement;
        }

        private Predicate<int> RebuildCondition()
        {
            return CompareOperator switch
            {
                ">=" => (x) => x >= CompareThreshold,
                "<=" => (x) => x <= CompareThreshold,
                ">" => (x) => x > CompareThreshold,
                "<" => (x) => x < CompareThreshold,
                "!=" => (x) => x != CompareThreshold,
                _ => (x) => x == CompareThreshold,
            };
        }
    }
}
