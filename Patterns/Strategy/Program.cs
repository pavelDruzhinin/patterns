using System;
using Strategy.Ducks;

namespace Strategy
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
}
