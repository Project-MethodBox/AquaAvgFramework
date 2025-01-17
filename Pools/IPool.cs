using AquaAvgFramework.Animation;
using AquaAvgFramework.Controls;

namespace AquaAvgFramework.Pools;

public interface IPool<TSource>: IAnimationExecutable 
{
    public TSource Source { get; set; }
    
    public void Pause(GamePanel gamePanel);
    public void Resume(GamePanel gamePanel);
}