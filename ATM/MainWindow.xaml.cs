using System.Windows;

namespace Bank
{
    public partial class MainWindow : Window
    {
        private ATMViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ATMViewModel();
            DataContext = viewModel;
        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AmountTextBox.Text, out int amount))
            {
                bool useLargeBills = LargeBillsRadio.IsChecked == true;
                bool success = viewModel.Withdraw(amount, useLargeBills);
                if (!success)
                {
                    MessageBox.Show("Insufficient funds or the specified amount cannot be issued");
                }
            }
            else
            {
                MessageBox.Show("Enter the correct amount");
            }
        }

        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AmountTextBox.Text, out int amount))
            {
                if (viewModel.Banknotes.FirstOrDefault(b => b.Denomination == amount) != null)
                {
                    bool success = viewModel.Deposit(amount, 1);
                    if (!success)
                    {
                        MessageBox.Show("The limit on the number of banknotes has been exceeded (MAX = 100)");
                    }
                }
                else
                {
                    MessageBox.Show("The banknote is not recognized, try another one");
                }
            }
            else
            {
                MessageBox.Show("The banknote is not recognized, try another one");
            }
        }
    }
}