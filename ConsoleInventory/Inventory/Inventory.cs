using System;

namespace ConsoleInventory
{
    public class Inventory
    {
        public readonly bool IsDoll;
        public readonly float MaxWeight;

        private InventorySlot[] slots;
        private float weight;

        public IEnumerable<InventorySlot> Slots => slots;
        public float Weight => weight;

        public event Action<InventoryItem, InventorySlot> OnItemAdded;
        public event Action<InventoryItem, InventorySlot> OnItemRemoved;

        public Inventory(int slotCount, float maxWeight, bool isDoll)
        {
            slots = new InventorySlot[slotCount];
            for (int i = 0; i < slotCount; i++)
            {
                slots[i] = new InventorySlot();
            }

            weight = 0f;
            MaxWeight = maxWeight;
            IsDoll = isDoll;
        }

        private bool HasFreeSpace(float weightToAdd)
        {
            if (weight + weightToAdd <= MaxWeight)
                return true;

            return false;
        }

        public void Add(InventoryItem item, int stack)
        {
            float weightToAdd = stack * item.Weight;
            if (HasFreeSpace(weightToAdd) == false)
                return;

            var slot = GetSlot(item.Definition);
            
            if(slot == null)
            {
                slot = GetEmptySlot();
                if (slot == null)
                    return;
            }

            slot.Item = item;
            slot.Stack += stack;
            weight += weightToAdd;

            OnItemAdded?.Invoke(item, slot);
        }

        public void Add(InventoryItem item)
        {
            if (HasFreeSpace(item.Weight) == false)
                return;

            var slot = GetSlot(item.Definition);

            if (slot == null)
            {
                slot = GetEmptySlot();
                if (slot == null)
                    return;
            }

            slot.Item = item;
            slot.Stack++;
            weight += item.Weight;

            OnItemAdded?.Invoke(item, slot);
        }

        public void Remove(InventoryItem item)
        {
            var slot = GetSlot(item.Definition);

            if (slot == null)
                return;

            slot.Stack--;
            weight -= item.Weight;

            OnItemRemoved?.Invoke(item, slot);
        }

        public void Remove(InventoryItem item, int stack)
        {
            var slot = GetSlot(item.Definition);
            int stackToRemove = stack > slot.Stack ? slot.Stack : stack;

            if (slot == null)
                return;

            slot.Stack -= stackToRemove;
            weight -= item.Weight * stackToRemove;

            OnItemRemoved?.Invoke(item, slot);
        }

        public void RemoveStack(InventoryItem item)
        {
            var slot = GetSlot(item.Definition);

            if (slot == null)
                return;

            weight -= item.Weight * slot.Stack;
            slot.Stack = 0;

            OnItemRemoved?.Invoke(item, slot);
        }

        public void ClearAll()
        {
            foreach (var slot in slots)
            {
                slot.Stack = 0;
                slot.Item = null;
            }
        }

        private InventorySlot? GetEmptySlot()
        {
            foreach (var slot in slots)
            {
                if (slot.Item == null)
                    return slot;
            }

            return null;
        }

        private InventorySlot? GetSlot(ItemDefinition definition)
        {
            foreach (var slot in slots)
            {
                if (slot.Item == null)
                    continue;

                if (slot.Item.Definition == definition)
                    return slot;
            }

            return null;
        }
    }
}
