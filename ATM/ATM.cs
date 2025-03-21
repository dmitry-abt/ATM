﻿namespace Bank
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
            return false;
        }

        public void Deposit(int denomination, int count) { }
    }
}
