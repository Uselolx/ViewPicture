using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAppForCapgemini
{
    public class ObserableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}