using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using AquaAvgFramework.GameElements.Blocks;
using AquaAvgFramework.Global;
using static AquaAvgFramework.GameElements.Blocks.ChoiceDialogue;

namespace AquaAvgFramework.Controls
{
    /// <summary>
    /// ChoiceBubble.xaml 的交互逻辑
    /// </summary>
    public partial class ChoiceBubble : UserControl
    {
        public ChoiceBubble(List<ChoiceResult> choiceResults)
        {
            ObservableChoiceResults = new();
            choiceResults.ForEach(r => ObservableChoiceResults.Add(r));
            this.DataContext = this;
            InitializeComponent();
        }

        public string Capital
        {
            get => (string)GetValue(CapitalProperty);
            set => SetValue(CapitalProperty, value);
        }

        // Using a DependencyProperty as the backing store for Capital.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CapitalProperty =
            DependencyProperty.Register(nameof(Capital), typeof(string), typeof(ChoiceBubble), new PropertyMetadata("Arabidopsis"));


        public FontFamily CapitalFontFamily
        {
            get => (FontFamily)GetValue(CapitalFontFamilyProperty);
            set => SetValue(CapitalFontFamilyProperty, value);
        }

        // Using a DependencyProperty as the backing store for CapitalFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CapitalFontFamilyProperty =
            DependencyProperty.Register(nameof(CapitalFontFamily), typeof(FontFamily), typeof(ChoiceBubble), new PropertyMetadata(new FontFamily("Consolas")));

        public string Detail
        {
            get => (string)GetValue(DetailProperty);
            set => SetValue(DetailProperty, value);
        }

        // Using a DependencyProperty as the backing store for Detail.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetailProperty =
            DependencyProperty.Register(nameof(Detail), typeof(string), typeof(ChoiceBubble), new PropertyMetadata("Hello!"));

        public ObservableCollection<ChoiceDialogue.ChoiceResult> ObservableChoiceResults { get; set; }

        private void Selected(object sender, MouseButtonEventArgs e)
        {
            if (ChoiceBox.SelectedIndex == -1) return;
            if (!ValueManager.Shared.UpdateValue("%Selected%", ChoiceBox.SelectedIndex))
            {
                ValueManager.Shared.RegisterValue("%Selected%", ChoiceBox.SelectedIndex, true);
            }
            RaiseEvent(e);
        }
    }
}
