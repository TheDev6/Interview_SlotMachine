namespace ObjectOrientedSlotMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SlotHandle
    {
        private readonly IRandomProvider randomProvider;
        public SlotHandle(IRandomProvider randomProvider)
        {
            if (randomProvider == null) throw new ArgumentNullException(nameof(randomProvider));
            this.randomProvider = randomProvider;
        }

        public HandlePullResult Pull(List<SlotWheel> wheels)
        {
            //future, I would imagine there would be more complex win formulas that account for payout ratios and win history
            // for now we will use a simple random generator
            var result = new HandlePullResult { IsWinner = false };

            foreach (var wheel in wheels)
            {
                wheel.CurrentValue = this.SelectRandom(wheel.Values);
            }

            //The current win rule is that all wheels have the same value.
            //Real world must include endless combo value wins like wild cards ect.
            result.IsWinner = wheels.Select(w => w.CurrentValue).Distinct().Count() == 1;

            return result;
        }

        public string SelectRandom(List<string> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            var maxIndex = values.Count - 1;
            var randomIndex = this.randomProvider.Random(inclusiveMin: 0, inclusiveMax: maxIndex);
            var result = values[randomIndex];
            return result;
        }
    }
}
