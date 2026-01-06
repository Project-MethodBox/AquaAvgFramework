using AquaAvgFramework.Animation;
using System.Text.Json.Serialization;

namespace AquaAvgFramework.Spirits;

/// <summary>
/// Representing all free objects
/// </summary>
/// <typeparam name="TSource">The type of source for building objects</typeparam>

public interface ISpirit<TSource> : IAnimationExecutable
    where TSource : class
{
    public TSource Source { get; set; }
}
