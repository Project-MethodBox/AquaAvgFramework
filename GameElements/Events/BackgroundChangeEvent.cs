using System.Windows.Controls;
using AquaAvgFramework.Animation;
using AquaAvgFramework.Controls;
using System.Windows.Media.Imaging;
using System.IO;

namespace AquaAvgFramework.GameElements.Events;

public class BackgroundChangeEvent : IGameElement
{
    public int ElementId { get; set; }
    public string ImagePath { get; set; }

    public IAnimation? SwitchAnimation { get; set; }

    public BackgroundChangeEvent(int elementId, string imagePath, IAnimation? switchAnimation = null)
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
            var baseDicrectory = System.AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                var image = new Image();
                image.Source = new BitmapImage(new(Path.Combine(baseDicrectory, ImagePath)));
                SwitchAnimation?.ExecuteAnimation(gamePanel, image);
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("文件不存在");
            }
        }
        else
        {
            gamePanel.BackImage.Source = new BitmapImage(new(ImagePath));
        }
    }
}