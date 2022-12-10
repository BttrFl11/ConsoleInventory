using System;

namespace ConsoleInventory
{
    public class InventorySlot
    {
        public InventoryItem? Item;

        private int stack;
        public int Stack
        {
            get => stack;
            set
            {
                stack = value;
                if (stack < 0)
                    stack = 0;

                if (stack == 0)
                    Item = null;
            }
        }

        public float Weight => Item.Definition.Weight * Stack;
    }
}
