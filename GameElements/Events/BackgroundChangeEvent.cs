using System.Windows.Controls;
using AquaAvgFramework.Animation;
using AquaAvgFramework.Controls;
using System.Windows.Media.Imaging;

namespace AquaAvgFramework.GameElements.Events;
public class BackgroundChangeEvent : IGameElement
{
    public int ElementId { get; set; }
    public Uri ImagePath { get; set; }

    public IAnimation? SwitchAnimation { get; set; }

    public BackgroundChangeEvent(int elementId, Uri imagePath, IAnimation? switchAnimation = null)
    {
        ElementId= elementId;
        ImagePath= imagePath;
        SwitchAnimation= switchAnimation;
    }

    public BackgroundChangeEvent() { }

    public void Enter(GamePanel gamePanel)
    {
        if (SwitchAnimation is not null)
        {
            var image = new Image();
            image.Source = new BitmapImage(ImagePath);
            SwitchAnimation?.ExecuteAnimation(gamePanel, image);
        }
        else
        {
            gamePanel.BackImage.Source = new BitmapImage(ImagePath);
        }
    }
}