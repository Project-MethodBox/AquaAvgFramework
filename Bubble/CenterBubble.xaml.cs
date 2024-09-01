using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AquaAvgFramework.Bubble
{
    /// <summary>
    /// CenterBubble.xaml 的交互逻辑
    /// </summary>
    public partial class CenterBubble : UserControl
    {
        public CenterBubble()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Background color of bubble card
        /// </summary>
        public SolidColorBrush BackGroundColor
        {
            get => (SolidColorBrush)GetValue(BackGroundColorProperty);
            set => SetValue(BackGroundColorProperty, value);
        }

        // Using a DependencyProperty as the backing store for BackGroundColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackGroundColorProperty =
            DependencyProperty.Register(nameof(BackGroundColor), typeof(SolidColorBrush), typeof(CenterBubble), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(11, 45, 14))));


    }
}
