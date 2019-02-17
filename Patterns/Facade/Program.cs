using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class HomeTheaterFacade
    {
        private readonly Amplifier amplifier;
        private readonly Tuner tuner;
        private readonly DvdPlayer dvdPlayer;
        private readonly CdPlayer cdPlayer;
        private readonly Projector projector;
        private readonly TheaterLights lights;
        private readonly Screen screen;
        private readonly PopcornPopper popper;

        public HomeTheaterFacade(Amplifier amplifier,
            Tuner tuner,
            DvdPlayer dvdPlayer,
            CdPlayer cdPlayer,
            Projector projector,
            TheaterLights lights,
            Screen screen,
            PopcornPopper popper)
        {
            this.amplifier = amplifier;
            this.tuner = tuner;
            this.dvdPlayer = dvdPlayer;
            this.cdPlayer = cdPlayer;
            this.projector = projector;
            this.lights = lights;
            this.screen = screen;
            this.popper = popper;
        }

        public void WatchMovie(string movieName)
        {
            Console.WriteLine("Get ready to watch a movie...");
            popper.On();
            popper.Pop();
            lights.Dim(10);
            screen.Down();
            projector.On();
            projector.WideScreenMode();
            amplifier.On();
            amplifier.SetDvd(dvdPlayer);
            amplifier.SetSurroundSound();
            amplifier.SetVolume(5);
            dvdPlayer.On();
            dvdPlayer.Play(movieName);
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting movie theater down...");
            popper.Off();
            lights.On();
            screen.Up();
            projector.Off();
            amplifier.Off();
            dvdPlayer.Stop();
            dvdPlayer.Eject();
            dvdPlayer.Off();
        }
    }

    public class Amplifier
    {
        internal void Off()
        {
            throw new NotImplementedException();
        }

        internal void On()
        {
            throw new NotImplementedException();
        }

        internal void SetDvd(DvdPlayer dvdPlayer)
        {
            throw new NotImplementedException();
        }

        internal void SetSurroundSound()
        {
            throw new NotImplementedException();
        }

        internal void SetVolume()
        {
            throw new NotImplementedException();
        }
    }

    public class Tuner
    {

    }

    public class DvdPlayer
    {
        internal void Eject()
        {
            throw new NotImplementedException();
        }

        internal void Off()
        {
            throw new NotImplementedException();
        }

        internal void On()
        {
            throw new NotImplementedException();
        }

        internal void Play(string movieName)
        {
            throw new NotImplementedException();
        }

        internal void Stop()
        {
            throw new NotImplementedException();
        }
    }

    public class Projector
    {
        internal void Off()
        {
            throw new NotImplementedException();
        }

        internal void On()
        {
            throw new NotImplementedException();
        }

        internal void WideScreenMode()
        {
            throw new NotImplementedException();
        }
    }

    public class CdPlayer
    {

    }

    public class TheaterLights
    {
        internal void Dim(int v)
        {
            throw new NotImplementedException();
        }

        internal void On()
        {
            throw new NotImplementedException();
        }
    }

    public class Screen
    {
        internal void Down()
        {
            throw new NotImplementedException();
        }

        internal void Up()
        {
            throw new NotImplementedException();
        }
    }

    public class PopcornPopper
    {
        internal void Off()
        {
            throw new NotImplementedException();
        }

        internal void On()
        {
            throw new NotImplementedException();
        }

        internal void Pop()
        {
            throw new NotImplementedException();
        }
    }
}
