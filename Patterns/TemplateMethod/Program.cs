using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Coffee
    {
        private void PrepareRecipe()
        {
            BoilWater();
            BrewCoffeeGrinds();
            PourInCup();
            AddSugarAndMilk();
        }

        public void BoilWater()
        {
            Console.WriteLine("Boiling water");
        }

        public void BrewCoffeeGrinds()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }

        public void PourInCup()
        {
            Console.WriteLine("Pouring into cup");
        }

        public void AddSugarAndMilk()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }
    }

    public class Tea
    {
        void PrepareRecipe()
        {
            BoilWater();
            SteepTeaBug();
            PourInCup();
            AddLemon();
        }

        public void BoilWater()
        {
            System.Console.WriteLine("Boiling water");
        }

        public void SteepTeaBag()
        {
            System.Console.WriteLine("Steeping the tea");
        }
        public void AddLemon()
        {
            System.Console.WriteLine("Adding Lemon");
        }
        public void PourInCup()
        {
            System.Console.WriteLine("Pouring into cup");
        }
    }
}
