using System;

namespace ConsoleInventory
{
    public class SampleInventory
    {
        public readonly Inventory Bag;
        public readonly Inventory Doll;

        public SampleInventory(Inventory bag, Inventory doll)
        {
            Bag = bag;
            Doll = doll;
        }

        public void AddToBag(InventoryItem item)
        {
            Bag.Add(item);
        }

        public void AddToBag(InventoryItem item, int stack)
        {
            Bag.Add(item, stack);
        }

        public void AddToDoll(InventoryItem item)
        {
            Doll.Add(item);
        }

        public void RemoveFromBag(InventoryItem item)
        {
            Bag.Remove(item);
        }

        public void RemoveFromBag(InventoryItem item, int stack)
        {
            Bag.Remove(item, stack);
        }
    }
}
