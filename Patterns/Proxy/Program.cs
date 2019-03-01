using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            if (args.Length < 2)
            {
                System.Console.WriteLine("GumballMachine <name> <inventory>");
                Environment.Exit(0);
            }
            count = Convert.ToInt32(args[1]);
            var gumballMachine = new GumballMachine(count);
            var monitor = new GumballMonitor(gumballMachine);

            monitor.Report();
        }
    }

    public class GumballMachine
    {
        public string Location { get; }
        public int Count { get; private set; }
        public IState State { get; }
        public GumballMachine(string location, int count)
        {
            State = new SoldState(this);
            Location = location;
            Count = count;
        }
    }

    public class GumballMonitor
    {
        private readonly GumballMachine machine;

        public GumballMonitor(GumballMachine machine)
        {
            this.machine = machine;
        }

        public void Report()
        {
            System.Console.WriteLine($"Gumball Machine: {machine.Location}");
            System.Console.WriteLine($"Current Inventory: {machine.Count} gumballs");
            System.Console.WriteLine($"Current State {machine.State}");
        }
    }

    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
    }

    public class SoldState : IState
    {
        private readonly GumballMachine gumballMachine;

        public SoldState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }
        public void Dispense()
        {
            gumballMachine.ReleaseBall();
            if (gumballMachine.Count > 0)
            {
                gumballMachine.SetState(gumballMachine.NoQuarterState);
            }
            else
            {
                Console.WriteLine("Oops, out of gumballs");
                gumballMachine.SetState(gumballMachine.SoldOutState);
            }
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Sorry, you already turned the crank");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Please wait, we're already giving you a gumbail");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Turning twice doen't get you another gumball!!");
        }
    }
}
