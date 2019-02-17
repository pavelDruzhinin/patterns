using System;
using Strategy.Ducks.Contracts;

namespace Strategy.Ducks
{
    public class FlyWithWings : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }
}
