namespace Bank
{
    public class ATM
    {
        public List<Banknote> Banknotes { get; private set; }
        private const int MaxBanknotesPerDenomination = 100;

        public ATM()
        {
            // test
            Banknotes = new List<Banknote>
            {
                new Banknote(5, 10),
                new Banknote(10, 10),
                new Banknote(20, 10),
                new Banknote(50, 10),
                new Banknote(100, 10),
                new Banknote(200, 10),
                new Banknote(500, 10)
            };
        }

        public int GetBalance()
        {
            return Banknotes.Sum(b => b.Denomination * b.Count);
        }

        public bool Withdraw(int amount, bool useLargeBills)
        {
            var sortedBanknotes = useLargeBills
                ? Banknotes.OrderByDescending(b => b.Denomination).ToList()
                : Banknotes.OrderBy(b => b.Denomination).ToList();

            var tempBanknotes = new List<Banknote>(Banknotes.Select(b => new Banknote(b.Denomination, b.Count)));

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

        public bool Deposit(int denomination, int count)
        {
            var banknote = Banknotes.FirstOrDefault(b => b.Denomination == denomination);
            if (banknote != null)
            {
                if (banknote.Count + count > MaxBanknotesPerDenomination)
                {
                    return false;
                }
                banknote.Count += count;
            }
            else
            {
                if (count > MaxBanknotesPerDenomination)
                {
                    return false;
                }
                Banknotes.Add(new Banknote(denomination, count));
            }
            return true;
        }
    }
}