namespace ObjectOrientedSlotMachine
{
    using System;
    using System.Collections.Generic;

    public class SlotMachine
    {
        public SlotMachine(List<SlotWheel> wheels, SlotHandle slotHandle)
        {
            //Note validation of slot build can be moved to another responsibility, but for now let's do the basics.
            if (wheels == null) throw new ArgumentNullException(nameof(wheels));
            if (slotHandle == null) throw new ArgumentNullException(nameof(slotHandle));
            if (wheels.Count < 3)
            {
                throw new Exception($"There must me a minmum of 3 values per Slot Wheel. {wheels.Count} were given."); 
            }

            this.SlotHandle = slotHandle;
            this.Wheels = wheels;
        }
        public List<SlotWheel> Wheels { get; private set; }
        public SlotHandle SlotHandle { get; private set; }
    }
}
