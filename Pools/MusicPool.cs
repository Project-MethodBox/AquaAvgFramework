using AquaAvgFramework.Controls;
using System.Windows.Media;

namespace AquaAvgFramework.Pools;

public class MusicPool(int elementId, string source) : IPool<string>
{
    private MediaPlayer _musicPlayer;

    public int ElementId { get; set; } = elementId;
    
    public void Enter(GamePanel gamePanel)
    {
        if (source == string.Empty)
        {
            gamePanel.MediaPlayer.Stop();
            return;
        }
        
        gamePanel.MediaPlayer.Open(new Uri(source));
        gamePanel.MediaPlayer.Play();
    }

    public string Source { get; set; } = source;
    public int Duration { get; set; }
}