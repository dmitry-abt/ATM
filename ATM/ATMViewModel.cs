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

        public bool Deposit(int denomination, int count)
        {
            bool result = atm.Deposit(denomination, count);
            OnPropertyChanged(nameof(Balance));
            OnPropertyChanged(nameof(Banknotes));
            return result;
        }

        public bool Withdraw(int amount, bool useLargeBills)
        {
            bool result = atm.Withdraw(amount, useLargeBills);
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