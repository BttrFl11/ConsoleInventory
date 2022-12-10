using System;

namespace ConsoleInventory
{
    public class InventoryItem
    {
        private ItemDefinition definition;
        public ItemDefinition Definition => definition;

        public string Name => definition.Name;
        public float Weight => definition.Weight;

        public InventoryItem(ItemDefinition definition)
        {
            this.definition = definition;
        }
    }
}
