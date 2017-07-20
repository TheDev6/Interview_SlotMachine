namespace ObjectOrientedSlotMachine.Tests
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using Tynamix.ObjectFiller;
    using Xunit;

    public class SlotHandle_Tests
    {
        [Fact]
        public void SlotHandle_Constructor_ShouldThrow_OnNullRandomProvider()
        {
            var act = new Action(() =>
            {
                var sut = new SlotHandle(null);
            });

            act.ShouldThrow<ArgumentNullException>(because: "Random Provider is required and was null");
        }

        [Fact]
        public void SlotHandle_Pull_ShouldWin()
        {
            var wheels = SlotMachineBuilder.BuildDefaultSlotMachine().Wheels;

            var subRandom = Substitute.For<IRandomProvider>();
            subRandom.Random(inclusiveMin: Arg.Any<int>(), inclusiveMax: Arg.Any<int>()).Returns(2);//carefull of the assumption that all wheels have the same value at the same index!

            var sut = new SlotHandle(subRandom);

            var result = sut.Pull(wheels);

            result.IsWinner.Should().BeTrue(because: "the matching values meet the condition for winner");
        }
    }
}
