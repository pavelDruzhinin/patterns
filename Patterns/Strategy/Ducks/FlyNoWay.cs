using System;
using Strategy.Ducks.Contracts;

namespace Strategy.Ducks
{
    public class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly");
        }
    }
}
