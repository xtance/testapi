namespace WebApplication1
{
    public class Item
    {
        private static readonly Dictionary<string, Item> _items = new();

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description   { get; set; }

        public Item(string name, int price, string description)
        {
            this.Guid = Guid.NewGuid();
            this.Name = name;
            this.Price = price;
            this.Description = description;
            Item._items.Add(this.Guid.ToString(), this);
        }

        public bool Remove()
        {
            Item._items.Remove(this.Guid.ToString());
            return true;
        }

        public static Item[] GetAll()
        {
            Item[] items = Item._items.Values.ToArray();
            return items;
        }

        public static Item? GetOne(Guid guid)
        {
            Item._items.TryGetValue(guid.ToString(), out Item? item);
            return item;
        }
    }
}
