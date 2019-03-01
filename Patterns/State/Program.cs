using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            var gumballMachine = new GumballMachine(5);

            System.Console.WriteLine(gumballMachine);

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();

            System.Console.WriteLine(gumballMachine);

            gumballMachine.InsertQuarter();
            gumballMachine.EjectQuarter();
            gumballMachine.TurnCrank();

            System.Console.WriteLine(gumballMachine);
        }
    }

    public class GumballMachine
    {
        private GumballMachineState _state = GumballMachineState.SoldOut;
        private int _count = 0;
        public GumballMachine(int count)
        {
            _count = count;
        }

        public override string ToString()
        {
            return $"GumballMachine State: {_state.ToString()}";
        }

        public void InsertQuarter()
        {
            var message = string.Empty;
            switch (_state)
            {
                case GumballMachineState.HasQuarter:
                    message = "You can't insert another quarter";
                    break;
                case GumballMachineState.NoQuarter:
                    _state = GumballMachineState.HasQuarter;
                    message = "You inserted quarter";
                    break;
                case GumballMachineState.SoldOut:
                    message = "You can't insert a quarter, the machine is sold out";
                    break;
                case GumballMachineState.Sold:
                    message = "Please wait, we're already giving you a gumbail";
                    break;
                default:
                    break;
            }
            System.Console.WriteLine(message);
        }

        public void EjectQuarter()
        {
            var message = string.Empty;
            switch (_state)
            {
                case GumballMachineState.HasQuarter:
                    message = "Quarter returned";
                    _state = GumballMachineState.NoQuarter;
                    break;
                case GumballMachineState.NoQuarter:
                    message = "You haven't inserted a quarter";
                    break;
                case GumballMachineState.SoldOut:
                    message = "You can't eject, you haven't inserted a quarter yet";
                    break;
                case GumballMachineState.Sold:
                    message = "Sorry, you already turned the crank";
                    break;
                default:
                    break;
            }
            System.Console.WriteLine(message);
        }

        public void TurnCrank()
        {
            var message = string.Empty;
            switch (_state)
            {
                case GumballMachineState.Sold:
                    message = "Turning twice doen't get you another gumball!!";
                    break;
                case GumballMachineState.NoQuarter:
                    message = "You turned but there's no quarter";
                    break;
                case GumballMachineState.SoldOut:
                    message = "You turned, but there are no gumballs";
                    break;
                case GumballMachineState.HasQuarter:
                    System.Console.WriteLine("You turned");
                    _state = GumballMachineState.Sold;
                    Dispense();
                    return;
                default:
                    break;
            }
            System.Console.WriteLine(message);
        }

        public void Dispense()
        {
            switch (_state)
            {
                case GumballMachineState.Sold:
                    System.Console.WriteLine("A gumball comes rolling out the slot");
                    _count--;
                    _state = _count == 0 ? GumballMachineState.SoldOut : GumballMachineState.NoQuarter;
                    if (_count == 0)
                        System.Console.WriteLine("Oops, out of gumballs");
                    break;
                case GumballMachineState.NoQuarter:
                    System.Console.WriteLine("You need pay first");
                    break;
                case GumballMachineState.SoldOut:
                case GumballMachineState.HasQuarter:
                    System.Console.WriteLine("No gumball dispensed");
                default:
            }
        }
    }

    public enum GumballMachineState
    {
        SoldOut,
        NoQuarter,
        HasQuarter,
        Sold
    }
}
