using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AquaAvgFramework.Animation;
using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Controls;

namespace AquaAvgFramework.Spirits
{
    [Attributes.ApplyAnimation(false)]
    [Attributes.LimitExecution]
    public sealed class Avatar : ISpirit<Uri>
    {
        public int ElementId { get; set; }
        public AvatarType AvatarTypeInstance { get; set; }
        public Uri Source { get; set; }
        public EnterContext? EnterContext { get; set; }
        public ExitContext? ExitContext { get; set; }
        private Grid? _instance;
        private Panel? _avatarContainer;

        public Avatar(
            AvatarType avatarTypeInstance,
            int elementId,
            EnterContext? enterContext,
            ExitContext? exitContent,
            Uri source)
        {
            ElementId= elementId;
            AvatarTypeInstance= avatarTypeInstance;
            Source= source;
            EnterContext= enterContext;
            ExitContext= exitContent;
        }

        public Avatar() { }

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

            // Switch container context
            _avatarContainer = AvatarTypeInstance == AvatarType.Left
                ? gamePanel.LeftAvatarPanel
                : gamePanel.RightAvatarPanel;

            // By installing a layer of Grid, it can be implemented normally
            // It's a bit too fucking lewd, isn't it?
            _instance = new Grid();
            _instance.Background = new BitmapCacheBrush(imageDisplay);

            _avatarContainer.Children.Add(_instance);
            EnterContext?.EnterAnimations.ForEach(a => a.ExecuteAnimation(gamePanel, _instance!));
        }

        public void Exit(GamePanel gamePanel)
        {
            ExitContext?.ExitAnimations.ForEach(a => a.ExecuteAnimation(gamePanel, _instance!));
        }

        public void SetLayerSerial(int layerSerial) => Panel.SetZIndex(_instance!, layerSerial);

        public void RemoveFromGrid(GamePanel _) => _avatarContainer!.Children.Remove(_instance);

        public enum AvatarType
        {
            Left,
            Right
        }
    }
}
