using AquaAvgFramework.Animation;
using AquaAvgFramework.Controls;
using System.Windows.Controls;
using System.Windows.Media;
using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Spirits;

namespace AquaAvgFramework.GameElements.Blocks
{
    [Attributes.ApplyAnimation(true)]
    [Attributes.BlockExecution]
    public class PlainDialogue(
        EnterContext? enterContext,
        ExitContext? exitContext,
        string capital,
        FontFamily? capitalFontFamily,
        string detail,
        FontFamily? detailFontFamily,
        int elementId)
        : IBlocking
    {
        public int ElementId { get; set; } = elementId;

        public string Capital { get; set; } = capital;
        public string Detail { get; set; } = detail;

        public FontFamily? CapitalFontFamily { get; set; } = capitalFontFamily;
        public FontFamily? DetailFontFamily { get; set; } = detailFontFamily;

        public EnterContext? EnterContext { get; set; } = enterContext;
        public ExitContext? ExitContext { get; set; } = exitContext;

        private CenterBubble? _instance;

        public void Enter(GamePanel gamePanel)
        {
            // Create bubble
            ArgumentNullException.ThrowIfNull(Capital);
            ArgumentNullException.ThrowIfNull(Detail);

            // Set parameter
            CapitalFontFamily ??= new FontFamily("SimHei");
            DetailFontFamily ??= new FontFamily("SimSun");

            _instance = new CenterBubble
            {
                Capital = Capital,
                Detail = Detail,
                CapitalFontFamily = CapitalFontFamily,
                DetailFontFamily = DetailFontFamily,
                Background = new SolidColorBrush(Color.FromArgb(0xCF, 0x33, 0x33, 0x33))
            };

            // Push bubble to panel
            gamePanel.CenterGrid.Children.Add(_instance);
            Grid.SetColumn(_instance, 1);

            EnterContext?.EnterAnimations.ForEach(a => a.ExecuteAnimation(gamePanel, _instance));
        }

        public void Exit(GamePanel gamePanel)
        {
            ExitContext?.ExitAnimations.ForEach(a => a.ExecuteAnimation(gamePanel.CenterGrid, _instance!));
        }

        public void SetLayerSerial(int layerSerial) => Panel.SetZIndex(_instance!, layerSerial);

        public void RemoveFromGrid(GamePanel gamePanel) => gamePanel.CenterGrid.Children.Remove(_instance);
    }
}