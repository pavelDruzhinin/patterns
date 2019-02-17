using System;
using System.Collections;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pancakeHouseMenu = new PancakeHouseMenu();
            var breakfastItems = pancakeHouseMenu.MenuItems;

            var dinerMenu = new DinerMenu();
            var lunchItems = dinerMenu.MenuItems;

            for (int i = 0; i < breakfastItems.Count; i++)
            {
                var menuItem = (MenuItem)breakfastItems[i];
                System.Console.WriteLine(menuItem.Name);
                System.Console.WriteLine(menuItem.Price);
                System.Console.WriteLine(menuItem.Description);
            }

            for (int i = 0; i < lunchItems.Length; i++)
            {
                var menuItem = lunchItems[i];
                System.Console.WriteLine(menuItem.Name);
                System.Console.WriteLine(menuItem.Price);
                System.Console.WriteLine(menuItem.Description);
            }
            Console.WriteLine("Hello World!");
        }
    }

    public class MenuItem
    {
        public readonly string Name;
        public readonly string Description;
        public readonly bool IsVegetarian;
        public readonly double Price;

        public MenuItem(string name, string description, bool isVegetarian, double price)
        {
            Name = name;
            Description = description;
            IsVegetarian = isVegetarian;
            Price = price;
        }


    }

    public class PancakeHouseMenu
    {
        public ArrayList MenuItems;
        public PancakeHouseMenu()
        {
            MenuItems = new ArrayList();

            AddItem("Reqular Pancake Breakfast", "Pancakes with fried eggs, sausege", false, 2.99);
            AddItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", false, 2.99);
        }

        public void AddItem(string name, string description, bool isVegeterian, double price)
        {
            var menuItem = new MenuItem(name, description, isVegetarian, price);
            MenuItems.Add(menuItem);
        }

        //other code
    }

    public class DinerMenu
    {
        const int MAX_ITEMS = 6;
        int numberOfItems = 0;
        public MenuItem[] MenuItems;

        public DinerMenu()
        {
            MenuItems = new MenuItem[MAX_ITEMS];

            AddItem("Vegeterian BLT", "(Fakin') with lettuce & tomato on whole wheat", true, 2.99);
            AddItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99);
        }

        public void AddItem(string name, string description, bool isVegeterian, double price)
        {

            if (numberOfItems >= MAX_ITEMS)
            {
                System.Console.WriteLine("Sorry, menu is full");
                return;
            }

            var menuItem = new MenuItem(name, description, isVegetarian, price);
            menuItem[numberOfItems] = menuItem;
            numberOfItems++;
        }

        //other code
    }


}
