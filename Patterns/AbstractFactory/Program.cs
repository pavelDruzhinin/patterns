using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IPizzaIngredientFactory
    {
        Dough CreateDough();
        Sauce CreateSauce();
        Pepperoni CreatePepperoni();
        Clam CreateClam();
    }

    public abstract class Pepperoni
    {

    }

    public abstract class Dough
    {

    }

    public abstract class Sauce
    {

    }

    public abstract class Clam
    {

    }

    public class NYPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThinCrustDough();
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Sauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public Clam CreateClam()
        {
            return new FreshClam();
        }
    }

    public class SlicedPepperoni : Pepperoni
    {

    }

    public class MarinaraSauce : Sauce
    {

    }

    public class ThinCrustDough : Dough
    {

    }

    public class FreshClam : Clam
    {

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
        protected Dough _dough;
        protected Pepperoni _peperonni;
        protected Sauce _sauce;
        protected Clam _clam;
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
            var ingredientFactory = new NYPizzaIngredientFactory();
            switch (pizzaType)
            {
                case PizzaType.Cheese:
                    return new NYCheesePizza(ingredientFactory);
                case PizzaType.Clam:
                    return new NYClamPizza(ingredientFactory);
                case PizzaType.Peperonni:
                    return new NYPeperonniPizza(ingredientFactory);
                case PizzaType.Veggie:
                    return new NYVeggiePizza(ingredientFactory);
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
        private IPizzaIngredientFactory _factory;
        public NYCheesePizza(IPizzaIngredientFactory factory)
        {
            _factory = factory;
        }
        public override void Prepare()
        {
            Console.WriteLine("Prepare NY Cheese Pizza");
            _dough = _factory.CreateDough();
            _peperonni = _factory.CreatePepperoni();
            _sauce = _factory.CreateSauce();
        }
    }
    public class NYPeperonniPizza : Pizza
    {
        private IPizzaIngredientFactory _factory;
        public NYCheesePizza(IPizzaIngredientFactory factory)
        {
            _factory = factory;
        }
        public override void Prepare()
        {
            Console.WriteLine("Prepare NY Peperonni Pizza");
            _dough = _factory.CreateDough();
            _peperonni = _factory.CreatePepperoni();
            _sauce = _factory.CreateSauce();
        }
    }

    public class NYClamPizza : Pizza
    {
        private IPizzaIngredientFactory _factory;
        public NYCheesePizza(IPizzaIngredientFactory factory)
        {
            _factory = factory;
        }
        public override void Prepare()
        {
            Console.WriteLine("Prepare NY Clam Pizza");
            _dough = _factory.CreateDough();
            _peperonni = _factory.CreatePepperoni();
            _sauce = _factory.CreateSauce();
            _clam = _factory.CreateClam();
        }
    }

    public class NYVeggiePizza : Pizza
    {
        private IPizzaIngredientFactory _factory;
        public NYCheesePizza(IPizzaIngredientFactory factory)
        {
            _factory = factory;
        }
        public override void Prepare()
        {
            Console.WriteLine("Prepare NY Veggie Pizza");
            _dough = _factory.CreateDough();
            _peperonni = _factory.CreatePepperoni();
            _sauce = _factory.CreateSauce();
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
