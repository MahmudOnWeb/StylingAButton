using System.ComponentModel;

namespace StylingAButton
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private General general;

        public BaseViewModel()
        {
            General = new General();
        }

        public General General
        {
            get { return general; }
            set
            {
                general = value;
                OnPropertyChanged("General");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}