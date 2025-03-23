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
            // -500 EUR
            bool success = viewModel.Withdraw(500);
            if (!success)
            {
                MessageBox.Show("Insufficient funds or the specified amount cannot be issued");
            }
        }

        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            // +100 EUR 
            viewModel.Deposit(100, 1);
        }
    }
}