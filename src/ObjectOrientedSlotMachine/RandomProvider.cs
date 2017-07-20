namespace ObjectOrientedSlotMachine
{
    using System;

    public class RandomProvider : IRandomProvider
    {
        private readonly Random random;

        public RandomProvider()
        {
            this.random = new Random();
        }

        public int Random(int inclusiveMin, int inclusiveMax)
        {
            //https://stackoverflow.com/questions/5063269/c-sharp-random-next-never-returns-the-upper-bound
            var result = this.random.Next(minValue: inclusiveMin, maxValue: inclusiveMax + 1);// max is exclusive, min is inclusive.
            return result;
        }
    }
}
