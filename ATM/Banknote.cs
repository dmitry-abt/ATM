namespace Bank
{
    public class Banknote
    {
        public int Denomination { get; set; } 
        public int Count { get; set; }       

        public Banknote(int denomination, int count)
        {
            Denomination = denomination;
            Count = count;
        }
    }
}