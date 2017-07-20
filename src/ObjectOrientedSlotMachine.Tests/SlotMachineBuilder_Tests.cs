namespace ObjectOrientedSlotMachine.Tests
{
    using FluentAssertions;
    using Xunit;

    public class SlotMachineBuilder_Tests
    {

        [Fact]
        public void BuildDefaultSlotMachine()
        {
            var slotMachine = SlotMachineBuilder.BuildDefaultSlotMachine();

            slotMachine.Wheels.Count.Should().Be(3, because: "The correct amount of wheels should exist");
            slotMachine.SlotHandle.Should().NotBeNull(because: "The slot handl must exist");
        }
    }
}
