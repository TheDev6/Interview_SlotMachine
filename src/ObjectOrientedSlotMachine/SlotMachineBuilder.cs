namespace ObjectOrientedSlotMachine
{
    using System.Collections.Generic;

    public static class SlotMachineBuilder
    {
        public static SlotMachine BuildDefaultSlotMachine()
        {
            var defaultValues = new List<string>
            {
                "Cherry",
                "Rasberry",
                "Grape"
            };

            var wheels = new List<SlotWheel>
            {
                new SlotWheel {Values = defaultValues, CurrentValue = null},
                new SlotWheel {Values = defaultValues, CurrentValue = null},
                new SlotWheel {Values = defaultValues, CurrentValue = null}
            };

            var random = new RandomProvider();
            var slotHandle = new SlotHandle(random);
            var slotMachine = new SlotMachine(wheels: wheels, slotHandle: slotHandle);

            return slotMachine;
        }
    }
}
