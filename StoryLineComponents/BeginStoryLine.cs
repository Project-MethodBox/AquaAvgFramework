using AquaAvgFramework.Controls;

namespace AquaAvgFramework.StoryLineComponents;

/// <summary>
/// Node representing the beginning of a linear StoreLine
/// </summary>
[Serializable]
public class BeginStoryLine(int elementId, int storyLineId) : IStoryLineComponent
{
    /// <summary>
    /// ID of current storyline
    /// </summary>
    public int StoryLineId { get; set; } = storyLineId;
    public int ElementId { get; set; } = elementId;

    public void Enter(GamePanel gamePanel)
    {
        if (gamePanel.CurrentStoryLine!.GameElements![0] != this)
        {
            throw new ArgumentException("The current storyline is damaged, please ensure that the storyline " +
                                        "has not been abnormally modified (such as in parallel)");
        }
    }
}