using System;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var pancakeHouseMenu = new Menu("Pancake House Menu", "Breakfast");
            var dinnerMenu = new Menu("Dinner Menu", "Lunch");
            var cafeMenu = new Menu("Cafe Menu", "Dinner");
            var dessertMenu = new Menu("Dessert Menu", "Dessert of course!");

            var allMenu = new Menu("Pancake House Menu", "Breakfast");

            allMenu.Add(pancakeHouseMenu);
            allMenu.Add(dinnerMenu);
            allMenu.Add(cafeMenu);

            dinnerMenu.Add(new MenuItem("Pasta", "Spaghetti with Marinara Sauce", true, 3.89d));
            dinnerMenu.Add(dessertMenu);

            dessertMenu.Add(new MenuItem("Apple pie", "Apple pie with a flakey crust", true, 1.59d));
            var waitress = new Waitress(allMenu);
            waitress.PrintMenu();
        }
    }

    ///<summary>
    /// Определение интерфейса листьев и комбиниционных узлов
    ///</summary>
    public abstract class MenuComponent
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public double Price { get; protected set; }
        public bool IsVegeterian { get; protected set; }
        public virtual void Print()
        {
            throw new NotSupportedException();
        }
        public virtual void Add(MenuComponent component)
        {
            throw new NotSupportedException();
        }
        public virtual void Remove(MenuComponent component)
        {
            throw new NotSupportedException();
        }
        public virtual MenuComponent GetChild(int childNumber)
        {
            throw new NotSupportedException();
        }
    }

    public class MenuItem : MenuComponent
    {
        public MenuItem(string name, string description, bool isVegeterian, double price)
        {
            Name = name;
            Description = description;
            IsVegeterian = isVegeterian;
            Price = price;
        }

        public override void Print()
        {
            System.Console.Write($" {Name}");
            if (IsVegeterian)
                System.Console.Write("(v)");
            System.Console.WriteLine($" {Price}");
            System.Console.WriteLine($"  -- {Description}");
        }
    }

    public class Waitress
    {
        public Waitress(MenuComponent allMenu)
        {
            AllMenu = allMenu;
        }

        public MenuComponent AllMenu { get; }

        public void PrintMenu()
        {
            AllMenu.Print();
        }
    }

    public class Menu : MenuComponent
    {
        private List<MenuComponent> _menuComponents;

        public Menu(string description, string name)
        {
            Name = name;
            Description = description;
            _menuComponents = new List<MenuComponent>();
        }

        public override void Add(MenuComponent component)
        {
            _menuComponents.Add(component);
        }

        public override void Remove(MenuComponent component)
        {
            _menuComponents.Remove(component);
        }

        public override MenuComponent GetChild(int childNumber)
        {
            return _menuComponents[childNumber];
        }

        public override void Print()
        {
            System.Console.Write($"\n {Name}");
            System.Console.WriteLine($", {Description}");
            System.Console.WriteLine("---------------");

            _menuComponents.ForEach(x => x.Print());
        }
    }
}
