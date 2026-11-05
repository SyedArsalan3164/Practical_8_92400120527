using System;
using System.Collections.Generic;
using Practical8.Models;

namespace Practical8.Views
{
    public class InventoryView
    {
        public string ShowMenu()
        {
            Console.WriteLine("\n===== INVENTORY MANAGEMENT =====");
            Console.WriteLine("1. Add Item\n2. View All Items\n3. Update Item\n4. Delete Item\n5. Exit");
            Console.Write("Enter choice: ");
            return Console.ReadLine();
        }

        public Item GetNewItem()
        {
            Item i = new Item();
            Console.Write("Enter Name: ");      i.Name = Console.ReadLine();
            Console.Write("Enter Quantity: ");  i.Quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Price: ");     i.Price = decimal.Parse(Console.ReadLine());
            return i;
        }

        public Item GetUpdatedItem()
        {
            Item i = new Item();
            Console.Write("Enter Item ID to update: ");  i.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter New Quantity: ");       i.Quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter New Price: ");          i.Price = decimal.Parse(Console.ReadLine());
            return i;
        }

        public int GetIdToDelete()
        {
            Console.Write("Enter Item ID to delete: ");
            return int.Parse(Console.ReadLine());
        }

        public void ShowItems(List<Item> items)
        {
            Console.WriteLine("ID   Name            Quantity   Price");
            Console.WriteLine("--------------------------------------");
            foreach (Item i in items)
                Console.WriteLine("{0,-4} {1,-15} {2,-10} {3:F2}", i.Id, i.Name, i.Quantity, i.Price);
        }

        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
