using System.Windows;
using System.Windows.Controls;

namespace Sautom.Client.Ui.Controls
{
    /// <summary>
    /// A simple control that provides a border around a region
    /// in order to display the region's name in a header.
    /// </summary>
    public sealed class RegionBorderControl : ContentControl
    {
	    public RegionBorderControl()
        {
            // Set default style key for generic template to be applied.
            DefaultStyleKey = typeof(RegionBorderControl);
        }

	    #region Dependency Property - RegionName

	    public static readonly DependencyProperty RegionNameProperty =
            DependencyProperty.Register("RegionName", typeof(string), typeof(RegionBorderControl),
                                         new PropertyMetadata(string.Empty, OnRegionNameChanged));

	    public string RegionName
        {
            get { return (string)GetValue(RegionNameProperty); }
            set { SetValue(RegionNameProperty, value); }
        }

	    private static void OnRegionNameChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            RegionBorderControl target = o as RegionBorderControl;
        }

	    #endregion
    }
}
