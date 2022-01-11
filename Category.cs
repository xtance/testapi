namespace WebApplication1
{
    public class Category
    {
        private static int _counter = 0;
        private static readonly List<Category> _categories = new();

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Item> Items { get; set; }

        public Category(string name)
        {
            this.Id = ++Category._counter;
            this.Name = name;
            this.Items = new List<Item>();
            Category._categories.Add(this);
        }

        public bool Remove()
        {
            Category._categories.Remove(this);
            return true;
        }

        public static Category[] GetAll()
        {
            return _categories.ToArray();
        }

        public static Category? GetOne(int id)
        {
            return Category._categories.Find(cat => cat.Id == id);
        }

        public void AddItem(Item item)
        {
            List<Category> cats = Category._categories.FindAll(cat => cat.Items.Contains(item));
            cats.ForEach(cat => cat.Items.Remove(item));
            this.Items.Add(item);
        }
    }
}
