using System.Windows.Controls;
using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Controls;
using AquaAvgFramework.Global;

namespace AquaAvgFramework.Spirits
{
    internal class Text(int elementId, EnterContext? enterContext, ExitContext? exitContext, string source, FontSet? fontSet = null)
        : ISpirit<string>
    {
        public int ElementId { get; set; } = elementId;
        public EnterContext? EnterContext { get; set; } = enterContext;
        public ExitContext? ExitContext { get; set; } = exitContext;
        public FontSet? FontSet { get; set; } = fontSet;
        public string Source { get; set; } = source;

        private TextBlock? _instance;

        public void Enter(GamePanel gamePanel)
        {
            // Create a text block in order to display text
            _instance = new TextBlock
            {
                Text = Source,
                FontSize = FontSet?.FontSize ?? 20
            };

            if (FontSet is not null)
            {
                _instance.Foreground = FontSet.Value.Foreground;
                _instance.Background = FontSet.Value.Background;
                _instance.FontFamily = FontSet.Value.FontFamily;
            }

            gamePanel.MainGrid.Children.Add(_instance);
            EnterContext?.EnterAnimations.ForEach(a => a.ExecuteAnimation(gamePanel, _instance!));
        }

        public void Exit(GamePanel gamePanel)
        {
            ExitContext?.ExitAnimations.ForEach(a => a.ExecuteAnimation(gamePanel, _instance!));
        }

        public void SetLayerSerial(int layerSerial) => Panel.SetZIndex(_instance!, layerSerial);

        public void RemoveFromGrid(GamePanel gamePanel) => gamePanel.MainGrid!.Children.Remove(_instance);
    }
}
