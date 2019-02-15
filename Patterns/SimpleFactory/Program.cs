using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class PizzaStore
    {
        private SimplePizzaFactory _factory;
        public PizzaStore(SimplePizzaFactory factory)
        {
            _factory = factory;
        }
        public Pizza OrderPizza(PizzaType pizzaType)
        {
            Pizza pizza = _factory.Create(pizzaType);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }
    }

    public class SimplePizzaFactory
    {
        public Pizza Create(PizzaType pizzaType)
        {
            switch (pizzaType)
            {
                case PizzaType.Cheese:
                    return new CheesePizza();
                case PizzaType.Clam:
                    return new ClamPizza();
                case PizzaType.Peperonni:
                    return new PeperonniPizza();
                case PizzaType.Veggie:
                    return new VeggiePizza();
                default:
                    return null;
            }
        }
    }

    public abstract class Pizza
    {
        public void Prepare() { }
        public void Bake() { }
        public void Cut() { }
        public void Box() { }
    }

    public class CheesePizza : Pizza
    {

    }
    public class PeperonniPizza : Pizza
    {

    }

    public class ClamPizza : Pizza
    {

    }

    public class VeggiePizza : Pizza
    {

    }

    public enum PizzaType
    {
        Cheese,
        Peperonni,
        Clam,
        Veggie
    }
}
