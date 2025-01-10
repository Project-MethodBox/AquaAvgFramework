using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AquaAvgFramework.Controls;

namespace AquaAvgFramework.GameElements.Events
{
    public class BackgroundChangeEvent(int elementId, Uri imagePath) : IGameElement
    {
        public int ElementId { get; set; } = elementId;
        public Uri ImagePath { get; set; } = imagePath;

        public void Enter(GamePanel gamePanel)
        {
            gamePanel.BackImage.Source = new BitmapImage(ImagePath);
        }
    }
}
