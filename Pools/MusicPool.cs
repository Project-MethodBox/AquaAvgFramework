using System.Windows.Controls;
using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Controls;

namespace AquaAvgFramework.Pools;

public class MusicPool(int elementId, string source) : IPool<string>
{
    private MediaElement _musicPlayer;

    public int ElementId { get; set; } = elementId;
    
    public void Enter(GamePanel gamePanel)
    {
        _musicPlayer = new MediaElement
        {
            Source = new(Source)
        };
        _musicPlayer.Play();
    }

    public EnterContext? EnterContext { get; set; }
    public ExitContext? ExitContext { get; set; }
    public void RemoveFromGrid(GamePanel gamePanel)
    {
        _musicPlayer.Stop();
    }

    public void Exit(GamePanel gamePanel)
    {
        _musicPlayer.Stop();
    }

    public required string Source { get; set; } = source;
    
    public void Pause(GamePanel gamePanel)
    {
        _musicPlayer.Pause();
    }

    public void Resume(GamePanel gamePanel)
    {
        _musicPlayer.Play();
    }
}