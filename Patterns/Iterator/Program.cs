using System;
using System.Collections;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pancakeHouseMenu = new PancakeHouseMenu();
            var dinerMenu = new DinerMenu();
            var waitress = new Waitress(pancakeHouseMenu, dinerMenu);
            waitress.PrintMenu();
        }
    }

    public class Waitress
    {
        private readonly PancakeHouseMenu pancakeHouseMenu;
        private readonly DinerMenu dinerMenu;

        public Waitress(PancakeHouseMenu pancakeHouseMenu, DinerMenu dinerMenu)
        {
            this.pancakeHouseMenu = pancakeHouseMenu;
            this.dinerMenu = dinerMenu;
        }

        public void PrintMenu()
        {
            var pancakeIterator = pancakeHouseMenu.CreateIterator();
            var dinerIterator = dinerMenu.CreateIterator();

            System.Console.WriteLine("MENU\n----\nBreakfast");
            PrintMenu(pancakeIterator);
            System.Console.WriteLine("\nLunch");
            PrintMenu(dinerIterator);
        }

        private void PrintMenu(Iterator<MenuItem> iterator)
        {
            while (iterator.HasNext())
            {
                var menuItem = iterator.Next();
                System.Console.WriteLine(menuItem.Name);
                System.Console.WriteLine(menuItem.Price);
                System.Console.WriteLine(menuItem.Description);
            }
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
        private ArrayList _menuItems;
        public PancakeHouseMenu()
        {
            _menuItems = new ArrayList();

            AddItem("Reqular Pancake Breakfast", "Pancakes with fried eggs, sausege", false, 2.99);
            AddItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", false, 2.99);
        }

        public void AddItem(string name, string description, bool isVegetarian, double price)
        {
            var menuItem = new MenuItem(name, description, isVegetarian, price);
            _menuItems.Add(menuItem);
        }

        public Iterator<MenuItem> CreateIterator()
        {
            return new PancakeHouseIterator(_menuItems);
        }
        //other code
    }

    public class DinerMenu
    {
        const int MAX_ITEMS = 6;
        int numberOfItems = 0;
        private MenuItem[] _menuItems;

        public DinerMenu()
        {
            _menuItems = new MenuItem[MAX_ITEMS];

            AddItem("Vegeterian BLT", "(Fakin') with lettuce & tomato on whole wheat", true, 2.99);
            AddItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99);
        }

        public Iterator<MenuItem> CreateIterator()
        {
            return new DinerMenuIterator(_menuItems);
        }
        public void AddItem(string name, string description, bool isVegetarian, double price)
        {

            if (numberOfItems >= MAX_ITEMS)
            {
                System.Console.WriteLine("Sorry, menu is full");
                return;
            }

            var menuItem = new MenuItem(name, description, isVegetarian, price);
            _menuItems[numberOfItems] = menuItem;
            numberOfItems++;
        }

        //other code
    }

    public interface Iterator<T>
    {
        bool HasNext();
        T Next();
    }

    public class DinerMenuIterator : Iterator<MenuItem>
    {
        private readonly MenuItem[] items;
        int position = 0;

        public DinerMenuIterator(MenuItem[] items)
        {
            this.items = items;
        }
        public bool HasNext()
        {
            return position < items.Length && items[position] != null;
        }

        public MenuItem Next()
        {
            var item = items[position];
            position++;
            return item;
        }
    }

    public class PancakeHouseIterator : Iterator<MenuItem>
    {
        private readonly ArrayList items;
        private int position = 0;

        public PancakeHouseIterator(ArrayList items)
        {
            this.items = items;
        }

        public bool HasNext()
        {
            return items.Count > position && items[position] != null;
        }

        public MenuItem Next()
        {
            var item = (MenuItem)items[position];
            position++;
            return item;
        }
    }
}
