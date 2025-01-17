namespace AquaAvgFramework.Animation.Context
{
    public class ExitContext(List<IAnimation> exitAnimations, int exitElementId = 0, int exitStoryLineId = 0)
    {
        public List<IAnimation> ExitAnimations { get; set; } = exitAnimations;
        public int ExitElementId { get; set; } = exitElementId;
        public int ExitStoryLineId { get; set; } = exitStoryLineId;
    }
}
