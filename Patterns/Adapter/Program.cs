using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IDuck
    {
        void Quack();
        void Fly();
    }

    public class MallardDuck : IDuck
    {
        public void Fly()
        {
            Console.WriteLine("Duck Fly");
        }

        public void Quack()
        {
            Console.WriteLine("Duck Quack");
        }
    }

    public interface ITurkey
    {
        void Gobble();
        void Fly();
    }

    public class WildTurkey : ITurkey
    {
        public void Fly()
        {
            Console.WriteLine("FLy Turkey");
        }

        public void Gobble()
        {
            Console.WriteLine("Gobble turkey");
        }
    }

    public class TurkeyAdapter : IDuck
    {
        private readonly ITurkey turkey;

        public TurkeyAdapter(ITurkey turkey)
        {
            this.turkey = turkey;
        }
        public void Fly()
        {
            turkey.Fly();
        }

        public void Quack()
        {
            turkey.Gobble();
        }
    }
}
