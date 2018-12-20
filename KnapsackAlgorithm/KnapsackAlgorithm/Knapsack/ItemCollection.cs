using System.Collections.Generic;

namespace KnapsackAlgorithm
{
    public class ItemCollection
    {
        public Dictionary<string, int> Contents = new Dictionary<string, int>();
        public int TotalValue;
        public int TotalWeight;

        public void AddItem(Item item, int quantity)
        {
            if (Contents.ContainsKey(item.Description)) Contents[item.Description] += quantity;
            else Contents[item.Description] = quantity;
            TotalValue += quantity * item.Value;
            TotalWeight += quantity * item.Weight;
        }

        public ItemCollection Copy()
        {
            var ic = new ItemCollection();
            ic.Contents = new Dictionary<string, int>(Contents);
            ic.TotalValue = TotalValue;
            ic.TotalWeight = TotalWeight;
            return ic;
        }
    }
}