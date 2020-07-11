using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Windows.UI.ViewManagement;

namespace StylingAButton
{
    public partial class AccentDemoView : UserControl
    {
        public AccentDemoView()
        {
            AddWindows10AccentColors();
            InitializeComponent();
        }

        private void AddWindows10AccentColors()
        {
            UISettings win10 = new UISettings();
            ResourceDictionary rd = new ResourceDictionary();
            rd.Add("AccentColor", Win10ColorToMediaColor(win10, UIColorType.Accent));
            rd.Add("AccentLightTwo", Win10ColorToMediaColor(win10, UIColorType.AccentLight2));
            rd.Add("AccentDarkTwo", Win10ColorToMediaColor(win10, UIColorType.AccentDark2));
            this.Resources.MergedDictionaries.Add(rd);
        }

        private Color Win10ColorToMediaColor(UISettings uiSettings, UIColorType colorType)
        {
            Windows.UI.Color win10Color = uiSettings.GetColorValue(colorType);
            Color mediaColor = Color.FromArgb(win10Color.A, win10Color.R, win10Color.G, win10Color.B);
            return mediaColor;
        }
    }
}
