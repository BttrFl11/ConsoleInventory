using ConsoleInventory.Debug;
using System;

namespace ConsoleInventory
{
    public class Program
    {
        private static void Main()
        {
            Inventory inventory = new(10, 100, false);
            Action<Inventory> debug = InventoryDebugger.Print;
            inventory.OnItemAdded += OnItemAdded;
            inventory.OnItemRemoved += OnItemRemoved;

            ItemDefinition definition1 = new("Apple", 0.4f);
            ItemDefinition definition2 = new("Key", 0.2f);
            ItemDefinition definition3 = new("Bottle", 0.5f);
            InventoryItem item1 = new(definition1);
            InventoryItem item2 = new(definition2);
            InventoryItem item3 = new(definition3);

            inventory.Add(item1, 2);

            inventory.Add(item2, 3);

            inventory.RemoveStack(item1);

            inventory.Add(item3, 1);

            debug(inventory);

            Console.ReadKey();
        }

        private static void OnItemAdded(InventoryItem item , InventorySlot slot)
        {
            Action<string> debug = Debug.Debug.Log;
            debug("");
            debug($"item \"{item.Name}\" was ADDED");
            debug("");
        }

        private static void OnItemRemoved(InventoryItem item, InventorySlot slot)
        {
            Action<string> debug = Debug.Debug.Log;
            debug("");
            debug($"item \"{item.Name}\" was REMOVED");
            debug("");
        }
    }
}