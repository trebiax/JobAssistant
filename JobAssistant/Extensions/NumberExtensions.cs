namespace JobAssistant.Extensions
{
    public static class NumberExtensions
    {
        public static decimal RoundToEvenCent(this decimal value)
        {
            return 0.02m / 1.00m * decimal.Round(value * (1.00m / 0.02m));
        }

        public static decimal RoundToClosestCent(this decimal value)
        {
            return decimal.Round(value, 2);
        }
    }
}
