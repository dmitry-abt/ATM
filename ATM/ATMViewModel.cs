using System.ComponentModel;

namespace Bank
{
    public class ATMViewModel : INotifyPropertyChanged
    {
        private ATM atm;

        public ATMViewModel()
        {
            atm = new ATM();
        }

        public int Balance => atm.GetBalance();

        public List<Banknote> Banknotes => atm.Banknotes;

        public void Deposit(int denomination, int count)
        {
            atm.Deposit(denomination, count);
            OnPropertyChanged(nameof(Balance));
            OnPropertyChanged(nameof(Banknotes));
        }

        public bool Withdraw(int amount)
        {
            bool result = atm.Withdraw(amount);
            OnPropertyChanged(nameof(Balance));
            OnPropertyChanged(nameof(Banknotes));
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}