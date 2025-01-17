using System.Windows.Controls;
using System.Windows.Media;
using AquaAvgFramework.Animation;
using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Controls;
using AquaAvgFramework.Spirits;

namespace AquaAvgFramework.GameElements.Blocks
{
    [Attributes.ApplyAnimation(true)]
    [Attributes.BlockExecution]
    public class ChoiceDialogue(
        EnterContext? enterContext, ExitContext? exitContext, string capital,
        FontFamily? capitalFontFamily,
        int elementId, List<ChoiceDialogue.ChoiceResult> choiceResults)
        : IGameElement, IBlocking
    {
        public int ElementId { get; set; } = elementId;

        public List<ChoiceResult> ChoiceResults { get; set; } = choiceResults;
        public string Capital { get; set; } = capital;

        public FontFamily? CapitalFontFamily { get; set; } = capitalFontFamily;

        public EnterContext? EnterContext { get; set; } = enterContext;
        public ExitContext? ExitContext { get; set; } = exitContext;

        private ChoiceBubble? _instance;

        public void Enter(GamePanel gamePanel)
        {
            // Create bubble
            ArgumentNullException.ThrowIfNull(Capital);

            CapitalFontFamily ??= new FontFamily("SimHei");

            _instance = new ChoiceBubble(ChoiceResults)
            {
                Capital = Capital,
                CapitalFontFamily = CapitalFontFamily,
            };

            // Push bubble to panel
            if (EnterContext is null)
            {
                _instance.Background = new SolidColorBrush(Color.FromArgb(0xCF, 0x33, 0x33, 0x33));
                gamePanel.CenterGrid.Children.Add(_instance);
                Grid.SetColumn(_instance, 1);
            }
            else
            {
                EnterContext?.EnterAnimations.ForEach(a => a.ExecuteAnimation(gamePanel, _instance));
            }
        }

        public class ChoiceResult(IGameElement? nextElement, string? text)
        {
            public string? Text { get; set; } = text;
            public IGameElement? NextElement { get; set; } = nextElement;
        }

        public void Exit(GamePanel gamePanel)
        {
            ExitContext?.ExitAnimations?.ForEach(a => a.ExecuteAnimation(gamePanel, _instance!));
        }

        public void SetLayerSerial(int layerSerial) => Panel.SetZIndex(_instance!, layerSerial);

        public void RemoveFromGrid(GamePanel gamePanel) => gamePanel.CenterGrid.Children.Remove(_instance);
    }
}