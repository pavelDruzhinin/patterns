using System;

namespace Ducks
{
    public class FlyRocketPowered : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with rocket!");
        }
    }
}
