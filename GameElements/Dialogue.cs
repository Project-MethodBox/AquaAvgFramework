using AquaAvgFramework.Animation;
using AquaAvgFramework.Controls;
using System.Windows.Media;

namespace AquaAvgFramework.GameElements
{
    class PlainDialogue(
        IAnimation? animation,
        string? capital,
        FontFamily? capitalFontFamily,
        string? detail,
        FontFamily? detailFontFamily,
        int elementId)
        : IGameElement
    {
        public int ElementId { get; set; } = elementId;

        public string? Capital { get; set; } = capital;
        public string? Detail { get; set; } = detail;

        public FontFamily? CapitalFontFamily { get; set; } = capitalFontFamily;
        public FontFamily? DetailFontFamily { get; set; } = detailFontFamily;

        public IAnimation? Animation { get; set; } = animation;

        public void Execute(GamePanel gamePanel)
        {
            // Create bubble
            ArgumentNullException.ThrowIfNull(Capital);
            ArgumentNullException.ThrowIfNull(Detail);

            CapitalFontFamily ??= new FontFamily("SimHei");
            DetailFontFamily ??= new FontFamily("SimSun");

            var bubble = new CenterBubble()
            {
                Capital = Capital!, 
                Detail = Detail, 
                CapitalFontFamily = CapitalFontFamily, 
                DetailFontFamily = DetailFontFamily
            };

            // Push bubble to panel
            if (Animation is null)
            {
                gamePanel.CenterGrid.Children.Clear();
                gamePanel.CenterGrid.Children.Add(bubble);
            }
            else
            {
                Animation?.ExecuteAnimation(gamePanel,bubble);
            }
        }
    }
}
