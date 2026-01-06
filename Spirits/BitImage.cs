using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Controls;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace AquaAvgFramework.Spirits
{
    [Attributes.ApplyAnimation(false)]
    [Attributes.LimitExecution]
    public class BitImage : ISpirit<Uri>
    {
        public int ElementId { get; set; }
        public Uri Source { get; set; }
        public EnterContext? EnterContext { get; set; }
        public ExitContext? ExitContext { get; set; }
        public Grid? _instance;

        public BitImage(
            int elementId,
            Uri source,
            EnterContext? enterContext,
            ExitContext? exitContext)
        {
            ElementId= elementId;
            Source= source;
            EnterContext= enterContext;
            ExitContext= exitContext;
        }

        public BitImage() { }

        public void Enter(GamePanel gamePanel)
        {
            // Create image _instance
            var img = new BitmapImage();
            img.BeginInit();
            img.UriSource = Source;
            img.EndInit();

            var imageDisplay = new Image
            {
                Source = img,
                Stretch = Stretch.Fill
            };

            // By installing a layer of Grid, it can be implemented normally
            // It's a bit too fucking lewd, isn't it?
            _instance = new Grid();
            _instance.Background = new BitmapCacheBrush(imageDisplay);

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
