using System.Windows.Media;

namespace AquaAvgFramework.Global
{
    public struct FontSet
    {
        public Brush? Background { get; set; }
        public Brush? Foreground { get; set; }
        public FontFamily? FontFamily { get; set; }
        public double FontSize { get; set; }
    }
}
