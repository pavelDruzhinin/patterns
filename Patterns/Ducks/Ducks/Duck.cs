using System;

namespace Ducks
{
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
}
