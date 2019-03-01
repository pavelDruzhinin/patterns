using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            var gumballMachine = new GumballMachine(5);

            Console.WriteLine(gumballMachine);

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();

            Console.WriteLine(gumballMachine);

            gumballMachine.InsertQuarter();
            gumballMachine.EjectQuarter();
            gumballMachine.TurnCrank();

            Console.WriteLine(gumballMachine);
        }
    }

    public class GumballMachine
    {
        public IState SoldOutState { get; }
        public IState NoQuarterState { get; }
        public IState HasQuarterState { get; }
        public IState SoldState { get; }
        public IState WinnerState { get; }
        private IState _state;
        public int Count { get; private set; }
        public GumballMachine(int count)
        {
            SoldOutState = new SoldOutState(this);
            NoQuarterState = new NoQuarterState(this);
            HasQuarterState = new HasQuarterState(this);
            SoldState = new SoldState(this);
            WinnerState = new WinnerState(this);
            Count = count;
            _state = Count > 0 ? NoQuarterState : SoldOutState;
        }

        public void InsertQuarter()
        {
            _state.InsertQuarter();
        }

        public void EjectQuarter()
        {
            _state.EjectQuarter();
        }

        public void TurnCrank()
        {
            _state.TurnCrank();
            _state.Dispense();
        }

        public void SetState(IState state)
        {
            _state = state;
        }

        public void ReleaseBall()
        {
            System.Console.WriteLine("A gumball comes rolling out the slot...");
            if (Count != 0)
                Count--;
        }

        public void Refill(int count)
        {
            Count = count;
            _state = NoQuarterState;
        }

        public override string ToString()
        {
            return $"GumballMachine State: {_state.ToString()}";
        }
    }

    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
    }

    public class WinnerState : IState
    {
        private readonly GumballMachine gumballMachine;

        public WinnerState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            System.Console.WriteLine("YOU'RE A WINNER! You get two balls for your quarter");
            gumballMachine.ReleaseBall();
            if (gumballMachine.Count == 0)
            {
                gumballMachine.SetState(gumballMachine.SoldOutState);
            }
            else
            {
                gumballMachine.ReleaseBall();
                if (gumballMachine.Count == 0)
                {
                    System.Console.WriteLine("Oops, out of gumballs!");
                    gumballMachine.SetState(gumballMachine.SoldOutState);
                }
                else
                {
                    gumballMachine.SetState(gumballMachine.NoQuarterState);
                }
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

    public class HasQuarterState : IState
    {
        private Random _randomWinner = new Random(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        private readonly GumballMachine gumballMachine;

        public HasQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }
        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Quarter returned");
            gumballMachine.SetState(gumballMachine.NoQuarterState);
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert another quarter");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned");
            var winner = _randomWinner.Next(10);
            if (winner == 0 && gumballMachine.Count > 0)
            {
                gumballMachine.SetState(gumballMachine.WinnerState);
            }
            else
            {
                gumballMachine.SetState(gumballMachine.SoldState);
            }
        }
    }

    public class NoQuarterState : IState
    {
        private readonly GumballMachine gumballMachine;

        public NoQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }
        public void Dispense()
        {
            Console.WriteLine("You need pay first");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You haven't inserted a quarter");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert another quarter");
            gumballMachine.SetState(gumballMachine.HasQuarterState);
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned but there's no quarter");
        }
    }

    public class SoldOutState : IState
    {
        private readonly GumballMachine gumballMachine;

        public SoldOutState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }
        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert a quarter, the machine is sold out");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned, but there are no gumballs");
        }
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
