namespace KnapsackAlgorithm
{   
    public class Item
    {
        public string Description;                
        public int Weight;
        public int Value = 1;

        public Item(string description, int weight)
        {
            Description = description;
            Weight = weight;          
        }
    }
}