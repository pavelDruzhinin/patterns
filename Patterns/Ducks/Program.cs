using System;

namespace Ducks
{
    class Program
    {
        static void Main(string[] args)
        {
            var mallardDuck = new MallardDuck();
            mallardDuck.PerformFly();
            mallardDuck.PerformQuack();

            var modelDuck = new ModelDuck();
            modelDuck.PerformFly();
            modelDuck.SetFlyBehavior(new FlyRocketPowered());


            Console.WriteLine("Hello World!");
        }
    }

    public abstract class Duck
    {
        protected IQuackBehavior _quackBehavior;
        protected IFlyBehavior _flyBehavior;

        public void PerformQuack()
        {
            _quackBehavior?.Quack();
        }

        public void PerformFly()
        {
            _flyBehavior?.Fly();
        }

        public void SetFlyBehavior(IFlyBehavior flyBehavior)
        {
            _flyBehavior = flyBehavior;
        }

        public void SetQuackBehavior(IQuackBehavior quackBehavior)
        {
            _quackBehavior = quackBehavior;
        }


        public abstract void Display();
        public void Swim()
        {
            Console.WriteLine("All ducks float, even decoys");
        }
    }

    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            _quackBehavior = new Quack();
            _flyBehavior = new FlyWithWings();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }

    /// <summary>
    /// Утка приманка
    /// </summary>
    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            _flyBehavior = new FlyNoWay();
            _quackBehavior = new Quack();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a model duck");
        }
    }

    public class RedheadDuck : Duck
    {
        public override void Display()
        {
            throw new NotImplementedException();
        }
    }

    public class RubberDuck : Duck
    {
        public override void Display()
        {
            throw new NotImplementedException();
        }
    }

    public class DucoyDuck : Duck
    {
        public override void Display()
        {
            throw new NotImplementedException();
        }
    }

    public class Quack : IQuackBehavior
    {
        void IQuackBehavior.Quack()
        {
            Console.WriteLine("Quack");
        }
    }

    public class Squeack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeack");
        }
    }

    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly");
        }
    }

    public class FlyWithWings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }

    public class FlyRocketPowered : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with rocket!");
        }
    }
}
