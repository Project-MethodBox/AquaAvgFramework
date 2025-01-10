using AquaAvgFramework.Controls;
using System.Windows;

namespace AquaAvgFramework.StoryLineComponents
{
    public class EndStoryLine(int elementId, StoryLine? nextStoryLine) : IStoryLineComponent
    {
        public StoryLine? NextStoryLine { get; set; } = nextStoryLine;
        public int ElementId { get; set; } = elementId;

        public void Enter(GamePanel gamePanel)
        {
            if (NextStoryLine is null) 
            {
                MessageBox.Show("游戏已结束（下一故事线为空），感谢您的游玩...", "游戏结束", MessageBoxButton.OK, MessageBoxImage.Information);
                Environment.Exit(0);
            }
            ArgumentNullException.ThrowIfNull(NextStoryLine.GameElements);

            if (NextStoryLine.GameElements[0].GetType() != typeof(BeginStoryLine))
            {
                throw new ArgumentException("The current storyline is damaged, please ensure " +
                                            "that the storyline starts with BeginStoryLine.");
            }
            gamePanel.CurrentStoryLine = NextStoryLine;
        }
    }
}
