namespace ObjectOrientedSlotMachine
{
    using System;
    using System.Threading;

    public class Program
    {
        static void Main(string[] args)
        {
            //https://en.wikipedia.org/wiki/Slot_machine trying to figure out what the part names are on a slot machine

            Console.WriteLine("Welcome to an object oriented Slot Machine!");

            var slotMachine = SlotMachineBuilder.BuildDefaultSlotMachine();

            var isContinue = true;
            while (isContinue)
            {
                Console.Write("Spin? (y|n):");
                var spinAnwswer = Console.ReadLine();

                if (spinAnwswer.ToLower().StartsWith("y"))
                {
                    var result = slotMachine.SlotHandle.Pull(slotMachine.Wheels);

                    foreach (var w in slotMachine.Wheels)
                    {
                        SuspenceDots(5);
                        Console.WriteLine(w.CurrentValue);
                    }

                    Console.WriteLine(result.IsWinner ? "You won!!!!!!!!!" : "Sorry, you lost.");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Continue?: (y|n):");
                    if (!Console.ReadLine().ToLower().StartsWith("y"))
                    {
                        isContinue = false;
                    }
                }
            }
        }

        static void SuspenceDots(int quantity, int speedMillisends = 50)
        {
            for (int i = 1; i <= quantity; i++)
            {
                Console.Write(".");
                Thread.Sleep(speedMillisends);
            }
        }
    }
}
