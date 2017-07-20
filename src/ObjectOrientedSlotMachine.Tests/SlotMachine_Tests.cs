namespace ObjectOrientedSlotMachine.Tests
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Tynamix.ObjectFiller;
    using Xunit;

    public class SlotMachine_Tests
    {
        [Fact]
        public void SlotMachine_Constructor_ShouldThrow_OnNullWheels()
        {
            var act = new Action(() =>
            {
                var sut = new SlotMachine(wheels: null, slotHandle: new SlotHandle(new RandomProvider()));
            });

            act.ShouldThrow<ArgumentNullException>(because: "Wheels are required and were null");
        }

        [Fact]
        public void SlotMachine_Constructor_ShouldThrow_OnNullHandle()
        {
            var slotWheels = new Filler<SlotWheel>().Create(3).ToList();

            var act = new Action(() =>
            {
                var sut = new SlotMachine(wheels: slotWheels, slotHandle: null);
            });

            act.ShouldThrow<ArgumentNullException>(because: "SlotHandle was required and was null");
        }

        [Fact]
        public void SlotMachine_Constructor_ShouldThrow_OnWheelCount()
        {
            var slotWheels = new Filler<SlotWheel>().Create(2).ToList();

            var act = new Action(() =>
            {
                var sut = new SlotMachine(wheels: slotWheels, slotHandle: new SlotHandle(new RandomProvider()));
            });

            act.ShouldThrow<Exception>(because: "The minimum Wheel count should be 3");
        }

        [Fact]
        public void SlotMachine_Should_RunWithoutError()
        {
            var sut = SlotMachineBuilder.BuildDefaultSlotMachine();

            var act = new Action(() => sut.SlotHandle.Pull(sut.Wheels));

            act.ShouldNotThrow<Exception>(because: "it should run without error on valid config");
        }

    }
}
