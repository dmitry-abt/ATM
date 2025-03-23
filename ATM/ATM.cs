namespace Bank
{
    public class ATM
    {
        public List<Banknote> Banknotes { get; private set; }

        public ATM()
        {
            // test
            Banknotes = new List<Banknote>
            {
                new Banknote(5, 0),
                new Banknote(10, 0),
                new Banknote(20, 0),
                new Banknote(50, 0),
                new Banknote(100, 0),
                new Banknote(200, 0),
                new Banknote(500, 0)
            };
        }

        public int GetBalance()
        {
            return Banknotes.Sum(b => b.Denomination * b.Count);
        }

        public bool Withdraw(int amount)
        {
            var tempBanknotes = new List<Banknote>(Banknotes);
            var sortedBanknotes = Banknotes.OrderByDescending(b => b.Denomination).ToList();

            foreach (var banknote in sortedBanknotes)
            {
                if (amount >= banknote.Denomination && banknote.Count > 0)
                {
                    int required = Math.Min(amount / banknote.Denomination, banknote.Count);
                    amount -= required * banknote.Denomination;
                    banknote.Count -= required;
                }
            }

            if (amount == 0)
            {
                return true;
            }
            else
            {
                Banknotes = tempBanknotes;
                return false;
            }
        }

        public void Deposit(int denomination, int count)
        {
            var banknote = Banknotes.FirstOrDefault(b => b.Denomination == denomination);
            if (banknote != null)
            {
                banknote.Count += count;
            }
            else
            {
                Banknotes.Add(new Banknote(denomination, count));
            }
        }
    }
}