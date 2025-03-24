using System.ComponentModel;

namespace Bank
{
    public class Banknote : INotifyPropertyChanged
    {
        private int denomination;
        private int count;

        public int Denomination
        {
            get => denomination;
            set
            {
                denomination = value;
                OnPropertyChanged(nameof(Denomination));
            }
        }

        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public Banknote(int denomination, int count)
        {
            Denomination = denomination;
            Count = count;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}