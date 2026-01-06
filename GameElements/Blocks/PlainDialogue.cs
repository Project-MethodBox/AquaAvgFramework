using AquaAvgFramework.Animation;
using AquaAvgFramework.Controls;
using System.Windows.Controls;
using System.Windows.Media;
using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Spirits;
using System.Text.Json.Serialization;

namespace AquaAvgFramework.GameElements.Blocks
{
    /// <summary>
    /// Option Dialog
    /// </summary>
    [Attributes.ApplyAnimation(true)]
    [Attributes.BlockExecution]
    [Serializable]
    public class PlainDialogue : IBlocking
    {
        public int ElementId { get; set; }

        public string Capital { get; set; }
        public string Detail { get; set; }

        [JsonIgnore]
        public FontFamily? CapitalFontFamily { get; set; } = new FontFamily("SimHei");

        [JsonIgnore]
        public FontFamily? DetailFontFamily { get; set; } = new FontFamily("SimSun");

        public EnterContext? EnterContext { get; set; }
        public ExitContext? ExitContext { get; set; }

        private CenterBubble? _instance;

        public PlainDialogue(
            EnterContext? enterContext,
            ExitContext? exitContext,
            string capital,
            FontFamily? capitalFontFamily,
            string detail,
            FontFamily? detailFontFamily,
            int elementId)
        {
            ElementId= elementId;
            Capital= capital;
            Detail= detail;
            CapitalFontFamily= capitalFontFamily;
            DetailFontFamily= detailFontFamily;
            EnterContext= enterContext;
            ExitContext= exitContext;
        }

        public PlainDialogue() { }

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