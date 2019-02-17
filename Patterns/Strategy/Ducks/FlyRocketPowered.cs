using System;
using Strategy.Ducks.Contracts;

namespace Strategy.Ducks
{
    public class FlyRocketPowered : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with rocket!");
        }
    }
}
