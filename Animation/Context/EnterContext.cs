namespace AquaAvgFramework.Animation.Context
{
    public class EnterContext(List<IAnimation> enterAnimations)
    {
        public List<IAnimation> EnterAnimations { get; set; } = enterAnimations;
    }
}
