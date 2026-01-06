using System.Windows;
using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Controls;

namespace AquaAvgFramework.Spirits
{
    [Serializable]
    public class Alert : ISpirit<string>
    {
        public int ElementId { get ; set; }
        public string Source { get; set; }
        public EnterContext? EnterContext { get; set; }
        public ExitContext? ExitContext { get; set; }

        public Alert(string source)
        {
            Source= source;
        }

        public Alert() { }

        public void Enter(GamePanel gamePanel)
        {
            System.Windows.MessageBox.Show(Source, "提示", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
        // Ignore
        public void Exit(GamePanel gamePanel)
        {
            return;
        }

        // Ignore
        public void RemoveFromGrid(GamePanel gamePanel)
        {
            return;
        }
    }
}
