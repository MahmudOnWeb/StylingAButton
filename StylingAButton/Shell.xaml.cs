using System.Windows;

namespace StylingAButton
{
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
