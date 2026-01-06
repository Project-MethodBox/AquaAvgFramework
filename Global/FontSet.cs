using System.Windows.Media;

namespace AquaAvgFramework.Global;

/// <summary>
/// Represents a series of parameters required for setting fonts
/// </summary>
public struct FontSet
{
    /// <summary>
    /// Background color of text
    /// </summary>
    public Brush? Background { get; set; }

    /// <summary>
    /// Color of Text
    /// </summary>
    public Brush? Foreground { get; set; }

    /// <summary>
    /// Font family of text
    /// </summary>
    public FontFamily? FontFamily { get; set; }

    /// <summary>
    /// Font size
    /// </summary>
    public double FontSize { get; set; }
}