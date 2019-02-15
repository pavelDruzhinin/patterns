using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Pizzeria
    {
        public Pizza OrderPizza(PizzaType pizzaType)
        {
            Pizza pizza;

            switch (pizzaType)
            {
                case PizzaType.Cheese:
                    pizza = new CheesePizza();
                    break;
                case PizzaType.Clam:
                    pizza = new ClamPizza();
                    break;
                case PizzaType.Peperonni:
                    pizza = new PeperonniPizza();
                    break;
                case PizzaType.Veggie:
                    pizza = new VeggiePizza();
                    break;
                default:
                    pizza = null;
                    break;
            }

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
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
