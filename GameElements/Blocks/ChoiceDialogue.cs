using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Controls;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Media;

namespace AquaAvgFramework.GameElements.Blocks;

[Attributes.ApplyAnimation(true)]
[Attributes.BlockExecution]
public class ChoiceDialogue : IGameElement, IBlocking
{
    public int ElementId { get; set; }

    public List<ChoiceResult> ChoiceResults { get; set; }
    public string Capital { get; set; }

    [JsonIgnore]
    public FontFamily? CapitalFontFamily { get; set; } = new FontFamily("SimHei");

    public EnterContext? EnterContext { get; set; }
    public ExitContext? ExitContext { get; set; }

    private ChoiceBubble? _instance;

    public ChoiceDialogue(
        EnterContext? enterContext, ExitContext? exitContext, string capital,
        FontFamily? capitalFontFamily,
        int elementId, List<ChoiceResult> choiceResults)
    {
        ElementId= elementId;
        ChoiceResults= choiceResults;
        Capital= capital;
        CapitalFontFamily= capitalFontFamily;
        EnterContext= enterContext;
        ExitContext= exitContext;
    }

    public ChoiceDialogue() { }

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

    public class ChoiceResult
    {
        public string? Text { get; set; }
        public IGameElement? NextElement { get; set; }

        public ChoiceResult(IGameElement? nextElement, string? text)
        {
            Text= text;
            NextElement= nextElement;
        }

        public ChoiceResult() { }
    }

    public void Exit(GamePanel gamePanel)
    {
        ExitContext?.ExitAnimations?.ForEach(a => a.ExecuteAnimation(gamePanel, _instance!));
    }

    public void SetLayerSerial(int layerSerial) => Panel.SetZIndex(_instance!, layerSerial);

    public void RemoveFromGrid(GamePanel gamePanel) => gamePanel.CenterGrid.Children.Remove(_instance);
}