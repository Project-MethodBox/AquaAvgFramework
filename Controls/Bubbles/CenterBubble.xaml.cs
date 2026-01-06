using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace AquaAvgFramework.Controls
{
    /// <summary>
    /// CenterBubble.xaml 的交互逻辑
    /// </summary>
    public partial class CenterBubble : UserControl
    {
        public CenterBubble()
        {
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
            DependencyProperty.Register(nameof(Capital), typeof(string), typeof(CenterBubble), new PropertyMetadata("Arabidopsis"));


        public FontFamily CapitalFontFamily
        {
            get => (FontFamily)GetValue(CapitalFontFamilyProperty);
            set => SetValue(CapitalFontFamilyProperty, value);
        }

        // Using a DependencyProperty as the backing store for CapitalFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CapitalFontFamilyProperty =
            DependencyProperty.Register(nameof(CapitalFontFamily), typeof(FontFamily), typeof(CenterBubble), new PropertyMetadata(new FontFamily("Consolas")));

        public string Detail
        {
            get => (string)GetValue(DetailProperty);
            set => SetValue(DetailProperty, value);
        }

        // Using a DependencyProperty as the backing store for Detail.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetailProperty =
            DependencyProperty.Register(nameof(Detail), typeof(string), typeof(CenterBubble), new PropertyMetadata("Hello!"));

        public FontFamily DetailFontFamily
        {
            get => (FontFamily)GetValue(DetailFontFamilyProperty);
            set => SetValue(DetailFontFamilyProperty, value);
        }

        // Using a DependencyProperty as the backing store for DetailFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetailFontFamilyProperty =
            DependencyProperty.Register(nameof(DetailFontFamily), typeof(FontFamily), typeof(CenterBubble), new PropertyMetadata(new FontFamily("Consolas")));

        private void Next(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("C!");
        }

        private void CenterBubble_OnLoaded(object sender, RoutedEventArgs e)
        {
            var characters = Detail.Select(c => c.ToString()).ToList();

            var index = 0;
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            timer.Tick += (_, _) =>
            {
                if (index < characters.Count)
                {
                    StoryBlock.Text += characters[index];
                    index++;
                }
                else
                {
                    timer.Stop();
                }
            };
            timer.Start();
        }
    }
}
