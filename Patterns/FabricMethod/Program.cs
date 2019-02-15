using System;

namespace FabricMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public abstract class PizzaStore
    {
        public Pizza OrderPizza(PizzaType pizzaType)
        {
            Pizza pizza = CreatePizza(pizzaType);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        protected abstract Pizza CreatePizza(PizzaType pizzaType);
    }

    public abstract class Pizza
    {
        public abstract void Prepare();
        public void Bake()
        {
            Console.WriteLine("Bake");
        }
        public void Cut()
        {
            Console.WriteLine("Cut");
        }
        public void Box()
        {
            Console.WriteLine("Box");
        }
    }

    public class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(PizzaType pizzaType)
        {
            switch (pizzaType)
            {
                case PizzaType.Cheese:
                    return new NYCheesePizza();
                case PizzaType.Clam:
                    return new NYClamPizza();
                case PizzaType.Peperonni:
                    return new NYPeperonniPizza();
                case PizzaType.Veggie:
                    return new NYVeggiePizza();
                default:
                    return null;
            }
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(PizzaType pizzaType)
        {
            switch (pizzaType)
            {
                case PizzaType.Cheese:
                    return new ChicagoCheesePizza();
                case PizzaType.Clam:
                    return new ChicagoClamPizza();
                case PizzaType.Peperonni:
                    return new ChicagoPeperonniPizza();
                case PizzaType.Veggie:
                    return new ChicagoVeggiePizza();
                default:
                    return null;
            }
        }
    }

    public class NYCheesePizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Prepare NY Cheese Pizza");
        }
    }
    public class NYPeperonniPizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Prepare NY Peperonni Pizza");
        }
    }

    public class NYClamPizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Prepare NY Clam Pizza");
        }
    }

    public class NYVeggiePizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Prepare NY Veggie Pizza");
        }
    }

    public class ChicagoCheesePizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Prepare Chicago Cheese Pizza");
        }
    }
    public class ChicagoPeperonniPizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Prepare Chicago Peperonni Pizza");
        }
    }

    public class ChicagoClamPizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Prepare Chicago Clam Pizza");
        }
    }

    public class ChicagoVeggiePizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Prepare Chicago Veggie Pizza");
        }
    }

    public enum PizzaType
    {
        Cheese,
        Peperonni,
        Clam,
        Veggie
    }
}
