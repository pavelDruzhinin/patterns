using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var tea = new Tea();
            tea.PrepareRecipe();

            var coffee = new Coffee();
            coffee.PrepareRecipe();
        }
    }

    public class Coffee : CaffeineBeverage
    {

        protected override void Brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }
    }

    public class Tea : CaffeineBeverage
    {

        protected override void Brew()
        {
            System.Console.WriteLine("Steeping the tea");
        }
        protected override void AddCondiments()
        {
            System.Console.WriteLine("Adding Lemon");
        }
    }

    public class CaffeineBeverage
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (IsCustomerWantsCondiments())
                AddCondiments();
        }

        protected abstract void Brew();
        protected abstract void AddCondiments();

        private void BoilWater()
        {
            System.Console.WriteLine("Boiling water");
        }

        private void PourInCup()
        {
            System.Console.WriteLine("Pouring into cup");
        }

        ///<summary>
        /// hook method
        ///</summary>
        protected virtual bool IsCustomerWantsCondiments()
        {
            return true;
        }
    }
}
