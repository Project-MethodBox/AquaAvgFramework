using System.Windows;
using AquaAvgFramework.Animation.Context;
using AquaAvgFramework.Controls;

namespace AquaAvgFramework.Spirits
{
    [Serializable]
    public class Alert(string source) : ISpirit<string>
    {
        public int ElementId { get ; set; }
        public string Source { get; set; } = source;
        public EnterContext? EnterContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ExitContext? ExitContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
