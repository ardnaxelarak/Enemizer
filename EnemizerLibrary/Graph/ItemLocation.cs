namespace EnemizerLibrary
{
    public class ItemLocation : Node
    {
        public Item Item { get; set; }

        public ItemLocation(string logicalId, string name, Item item)
        {
            this.LogicalId = logicalId;
            this.Name = name;
            this.Item = item;
        }
    }
}
