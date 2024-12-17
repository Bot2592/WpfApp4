namespace WpfJobCalculator
{
    public class TPair
    {
        public int First { get; set; }
        public int Second { get; set; }

        public TPair(int first, int second)
        {
            First = first;
            Second = second;
        }
    }

    public class TTime : TPair
    {
        public TTime(int hours, int minutes) : base(hours, minutes) { }

        public override string ToString()
        {
            return $"{First} год. {Second} хв.";
        }
    }

    public class TMoney : TPair
    {
        public TMoney(int hryvnias, int kopecks) : base(hryvnias, kopecks) { }

        public override string ToString()
        {
            return $"{First} грн. {Second} коп.";
        }
    }

    public class Job
    {
        public TTime Time { get; }
        public TMoney Money { get; }

        public string Description => $"Час: {Time}, Оплата: {Money}";

        public Job(TTime time, TMoney money)
        {
            Time = time;
            Money = money;
        }

        public decimal CalculateCost()
        {
            int totalMinutes = Time.First * 60 + Time.Second;
            decimal costPerMinute = Money.First + Money.Second / 100m;
            return totalMinutes * costPerMinute;
        }
    }
}
