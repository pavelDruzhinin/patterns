using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var remote = new SimpleRemoteControl();
            var light = new Light();
            var lightOnCommand = new LightOnCommand(light);

            remote.SetCommand(lightOnCommand);
            remote.ButtonPressed();
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class LightOnCommand : ICommand
    {
        private readonly Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.On();
        }
    }

    public class Light
    {
        public void On()
        {
            Console.WriteLine("Light is on");
        }

        public void Off()
        {
            Console.WriteLine("Light is off");
        }
    }

    public class GarageDoor
    {
        public void Up() { }
        public void Down() { }
        public void Stop() { }
        public void LightOn() { }
        public void LightOff() { }
    }

    public class GarageOpenDoorCommand : ICommand
    {
        private readonly GarageDoor garageDoor;

        public GarageOpenDoorCommand(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }
        public void Execute()
        {
            garageDoor.Up();
            garageDoor.LightOn();
        }
    }

    public class SimpleRemoteControl
    {
        private ICommand slot;

        public void SetCommand(ICommand command)
        {
            slot = command;
        }

        public void ButtonPressed()
        {
            slot.Execute();
        }
    }
}
