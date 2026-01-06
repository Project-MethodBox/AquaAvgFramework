using AquaAvgFramework.Controls;
using System.Windows.Media;

namespace AquaAvgFramework.Pools;

public class MusicPool : IPool<string>
{
    private MediaPlayer _musicPlayer;

    public MusicPool(int elementId, string source)
    {
        ElementId= elementId;
        Source= source;
    }

    public MusicPool() { }

    public int ElementId { get; set; }
    
    public void Enter(GamePanel gamePanel)
    {
        if (Source == string.Empty)
        {
            gamePanel.MediaPlayer.Stop();
            return;
        }
        
        gamePanel.MediaPlayer.Open(new Uri(Source));
        gamePanel.MediaPlayer.Play();
    }

    public string Source { get; set; }
    public int Duration { get; set; }
}