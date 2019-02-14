using System;

namespace Decorators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public abstract class Beverage
    {
        public abstract string Description { get; }
        public abstract float Cost();

        protected bool HasMilk()
        {

        }
        protected float SetMilk()
        {

        }
    }

    public class HouseBlend : Beverage
    {

    }

    public class DarkRoast : Beverage
    {

    }

    public class Decaf : Beverage
    {

    }

    public class Espresso : Beverage
    {

    }
}
