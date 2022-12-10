using System;

namespace ConsoleInventory.Debug
{
    public static class InventoryDebugger
    {
        public static void Print(Inventory inventory)
        {
            Debug.Log("===============");

            Debug.Log();
            Debug.Log("MaxWeight: " + inventory.MaxWeight + " kg");
            Debug.Log("Weight: " + inventory.Weight.ToString("0.0") + " kg");
            Debug.Log("Slots count: " + inventory.Slots.Count());
            Debug.Log();

            int i = 0;
            foreach (var slot in inventory.Slots)
            {
                Debug.Log("Slot - " + i);

                bool isNull = slot.Item == null;

                if(isNull == false)
                {
                    Debug.Log("name: " + slot.Item.Name);
                    Debug.Log("stack: " + slot.Stack);
                    Debug.Log("weight: " + slot.Item.Weight * slot.Stack + " kg");
                }
                else
                {
                    Debug.Log("null");
                }
                  
                Debug.Log("-----------");

                i++;
            }

            Debug.Log();
            Debug.Log("==============");
        }
    }
}
