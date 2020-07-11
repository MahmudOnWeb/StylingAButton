using StylingAButton.Views;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace StylingAButton
{
    public class MainViewModel : BaseViewModel
    {
        private object selected;
        private Tuple<string, FontFamily, FlowDirection>[] languagesAndFonts;
        private int changeIndex = 0;
        private ViewsForDisplay nextView;
        private string title, content;
        private double[] headerSizes = new double[7];
        private FlowDirection flowDirection;
        private FontFamily currentFont;
        private bool showLine;

        public MainViewModel()
        {
            DemoCommand = new SimpleCommand(Demo);
            ChangeViewCommand = new SimpleCommand(ChangeView);

            HeaderSizes[0] = 16; // body
            HeaderSizes[1] = 96; // H1 
            HeaderSizes[2] = 76;
            headerSizes[3] = 56;
            headerSizes[4] = 36;
            headerSizes[5] = 28;
            headerSizes[6] = 20;

            FindFontFamilies();
            nextView = ViewsForDisplay.Start;
            
            ChangeView();
            ShuffleFisherYates(languagesAndFonts);
        }

        public ICommand DemoCommand { get; private set; }
        public ICommand ChangeViewCommand { get; private set; }

        public object Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }

        public FontFamily CurrentFont
        {
            get { return currentFont; }
            set
            {
                currentFont = value;
                OnPropertyChanged("CurrentFont");
            }
        }

        public double[] HeaderSizes
        {
            get { return headerSizes; }
            set
            {
                headerSizes = value;
                OnPropertyChanged("HeaderSizes");
            }
        }

        public FlowDirection CurrentFlow
        {
            get { return flowDirection; }
            set
            {
                flowDirection = value;
                OnPropertyChanged("CurrentFlow");
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public bool ShowLine
        {
            get { return showLine; }
            set
            {
                showLine = value;
                OnPropertyChanged("ShowLine");
            }
        }

        private void Demo(object parameter)
        {
            DemoTopics topic = (DemoTopics)parameter;
            ChangeCulture();

            switch(topic)
            {
                case DemoTopics.Font:
                    Title = General.ComputerFont;
                    Content = General.ComputerFontContent;
                    break;
                case DemoTopics.Button:
                    Title = General.ComputingButton;
                    Content = General.ComputingButtonContent;
                    break;
                case DemoTopics.WritingSystem:
                    Title = General.WritingSystem;
                    Content = General.WritingSystemContent;
                    break;
                default:
                    break;
            }

            if(ShowLine == false)
            {
                ShowLine = true;
            }
        }

        private void ChangeView(object parameter = null)
        {
            switch(nextView)
            {
                case ViewsForDisplay.Start:
                    Selected = new StartView() { DataContext = this };
                    nextView = ViewsForDisplay.ColorPalette;
                    break;
                case ViewsForDisplay.ColorPalette:
                    Selected = new ColorPaletteView() { DataContext = this };
                    nextView = ViewsForDisplay.ColorPaletteDemo;
                    break;
                case ViewsForDisplay.ColorPaletteDemo:
                    Selected = new ColorPaletteDemoView() { DataContext = this };
                    nextView = ViewsForDisplay.Blueprint;
                    break;
                case ViewsForDisplay.Blueprint:
                    Selected = new BlueprintView() { DataContext = this };
                    nextView = ViewsForDisplay.BlueprintDemo;
                    break;
                case ViewsForDisplay.BlueprintDemo:
                    Selected = new BlueprintViewDemo() { DataContext = this };
                    nextView = ViewsForDisplay.Accent;
                    break;
                case ViewsForDisplay.Accent:
                    Selected = new AccentView() { DataContext = this };
                    nextView = ViewsForDisplay.AccentDemo;
                    break;
                case ViewsForDisplay.AccentDemo:
                    Selected = new AccentDemoView() { DataContext = this };
                    nextView = ViewsForDisplay.NestedPaths;
                    break;
                case ViewsForDisplay.NestedPaths:
                    Selected = new NestedPathsView() { DataContext = this };
                    nextView = ViewsForDisplay.NestedPathsDemo;
                    break;
                case ViewsForDisplay.NestedPathsDemo:
                    Selected = new NestedPathViewDemo() { DataContext = this };
                    nextView = ViewsForDisplay.Infographics;
                    break;
                case ViewsForDisplay.Infographics:
                    Selected = new InfographicsView() { DataContext = this };
                    nextView = ViewsForDisplay.InfographicsDemo;
                    break;
                case ViewsForDisplay.InfographicsDemo:
                    Selected = new InfographicsViewDemo() { DataContext = this };
                    nextView = ViewsForDisplay.Start;
                    break;
                default:
                    break;
            }
        }

        private void FindFontFamilies()
        {
            languagesAndFonts = new Tuple<string, FontFamily, FlowDirection>[15];

            languagesAndFonts[0] = new Tuple<string, FontFamily, FlowDirection>("en-US", (FontFamily)App.Current.TryFindResource("Rokkitt"), FlowDirection.LeftToRight);
            languagesAndFonts[1] = new Tuple<string, FontFamily, FlowDirection>("ar-SA", (FontFamily)App.Current.TryFindResource("Mirza"), FlowDirection.RightToLeft);
            languagesAndFonts[2] = new Tuple<string, FontFamily, FlowDirection>("bg-BG", (FontFamily)App.Current.TryFindResource("SofiaSans"), FlowDirection.LeftToRight);
            languagesAndFonts[3] = new Tuple<string, FontFamily, FlowDirection>("bn-BD", (FontFamily)App.Current.TryFindResource("Atma"), FlowDirection.LeftToRight);
            languagesAndFonts[4] = new Tuple<string, FontFamily, FlowDirection>("de-DE", (FontFamily)App.Current.TryFindResource("DinMittelschrift"), FlowDirection.LeftToRight);

            languagesAndFonts[5] = new Tuple<string, FontFamily, FlowDirection>("es-ES", (FontFamily)App.Current.TryFindResource("Montserrat"), FlowDirection.LeftToRight);
            languagesAndFonts[6] = new Tuple<string, FontFamily, FlowDirection>("fa-IR", (FontFamily)App.Current.TryFindResource("Samim"), FlowDirection.RightToLeft);
            languagesAndFonts[7] = new Tuple<string, FontFamily, FlowDirection>("fr-FR", (FontFamily)App.Current.TryFindResource("Garamond"), FlowDirection.LeftToRight);
            languagesAndFonts[8] = new Tuple<string, FontFamily, FlowDirection>("hi-IN", (FontFamily)App.Current.TryFindResource("Amita"), FlowDirection.LeftToRight);
            languagesAndFonts[9] = new Tuple<string, FontFamily, FlowDirection>("ja-JP", (FontFamily)App.Current.TryFindResource("SawarabiMincho"), FlowDirection.LeftToRight);

            languagesAndFonts[10] = new Tuple<string, FontFamily, FlowDirection>("ko-KR", (FontFamily)App.Current.TryFindResource("HiMelody"), FlowDirection.LeftToRight);
            languagesAndFonts[11] = new Tuple<string, FontFamily, FlowDirection>("pt-PT", (FontFamily)App.Current.TryFindResource("YrsaFromRosetta"), FlowDirection.LeftToRight);
            languagesAndFonts[12] = new Tuple<string, FontFamily, FlowDirection>("th-TH", (FontFamily)App.Current.TryFindResource("Sarabun"), FlowDirection.LeftToRight);
            languagesAndFonts[13] = new Tuple<string, FontFamily, FlowDirection>("ur-PK", (FontFamily)App.Current.TryFindResource("NafeesNastaleeq"), FlowDirection.RightToLeft);
            languagesAndFonts[14] = new Tuple<string, FontFamily, FlowDirection>("zh-CN", (FontFamily)App.Current.TryFindResource("ZhiMangXing"), FlowDirection.LeftToRight);
        }

        private void ChangeCulture()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languagesAndFonts[changeIndex].Item1);
            General = new General();

            CurrentFont = languagesAndFonts[changeIndex].Item2;
            CurrentFlow = languagesAndFonts[changeIndex].Item3;
            changeIndex++;

            if (changeIndex % 15 == 0)
            {
                ShuffleFisherYates(languagesAndFonts);
                changeIndex = 0;
            }
        }

        private static void ShuffleFisherYates(Tuple<string, FontFamily, FlowDirection>[] array)
        {
            Random random = new Random();

            int running = array.Length;
            while(running > 1)
            {
                int k = random.Next(running--);
                var temp = array[running];
                array[running] = array[k];
                array[k] = temp;
            }
        }
    }
}