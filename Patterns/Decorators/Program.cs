using System;

namespace Decorators
{
    class Program
    {
        static void Main(string[] args)
        {
            var espresso = new Espresso();
            Console.WriteLine($"{espresso.GetDescription()} {espresso.Cost()}");

            var darkRoast = new DarkRoast();
            darkRoast = new Mocha(darkRoast);
            darkRoast = new Mocha(darkRoast);
            darkRoast = new Whip(darkRoast);
            Console.WriteLine($"{darkRoast.GetDescription()} {darkRoast.Cost()}");

            var houseBlend = new HouseBlend();
            houseBlend = new Soy(houseBlend);
            houseBlend = new Mocha(houseBlend);
            houseBlend = new Whip(houseBlend);
            Console.WriteLine($"{houseBlend.GetDescription()} {houseBlend.Cost()}");
        }
    }

    public abstract class Beverage
    {
        protected string _description;
        public string GetDescription()
        {
            return _description;
        }
        public abstract double Cost();
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            _description = "House Blend";
        }

        public override double Cost()
        {
            return .89;
        }
    }

    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            _description = "Dark Roast";
        }

        public override double Cost()
        {
            return 3.99;
        }
    }

    public class Decaf : Beverage
    {
        public Decaf()
        {
            _description = "Decaf";
        }

        public override double Cost()
        {
            return .99;
        }
    }

    public class Espresso : Beverage
    {
        public Espresso()
        {
            _description = "Espresso";
        }

        public override double Cost()
        {
            return 1.99;
        }
    }

    public abstract class CondimentDecorator : Beverage
    {
        public new abstract string GetDescription();
    }

    public class Milk : CondimentDecorator
    {
        private Beverage _beverage;
        public Milk(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Milk";
        }

        public override double Cost()
        {
            return .30 + _beverage.Cost();
        }
    }

    public class Mocha : CondimentDecorator
    {
        private Beverage _beverage;
        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Mocha";
        }

        public override double Cost()
        {
            return .20 + _beverage.Cost();
        }
    }

    public class Soy : CondimentDecorator
    {
        private Beverage _beverage;
        public Soy(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Soy";
        }

        public override double Cost()
        {
            return .40 + _beverage.Cost();
        }
    }

    public class Whip : CondimentDecorator
    {
        private Beverage _beverage;
        public Whip(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Whip";
        }

        public override double Cost()
        {
            return .20 + _beverage.Cost();
        }
    }
}
