using AquaAvgFramework.GameElements;

namespace AquaAvgFramework.Pools;

/// <summary>
/// Provide streaming media playback services similar to pooling
/// </summary>
/// <typeparam name="TSource">Incoming source type</typeparam>

public interface IPool<TSource> : IGameElement
{
    /// <summary>
    /// Incoming type used to load streaming media
    /// </summary>
    public TSource Source { get; set; }
    
    /// <summary>
    /// Duration, set to 0 to indicate until the end
    /// </summary>
    public int Duration { get; set; }
}