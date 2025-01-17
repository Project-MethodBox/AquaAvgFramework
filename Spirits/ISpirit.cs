using AquaAvgFramework.Animation;

namespace AquaAvgFramework.Spirits
{
    public interface ISpirit<TSource> : IAnimationExecutable 
        where TSource : class
    {
        public TSource Source { get; set; }
    }
}
