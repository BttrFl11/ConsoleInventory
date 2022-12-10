using System;

namespace ConsoleInventory
{
    public class ItemDefinition
    {
        private string name;
        private float weight;

        public string Name => name;
        public float Weight => weight;

        public ItemDefinition(string name, float weight)
        {
            this.name = name;
            this.weight = weight;
        }
    }
}
