namespace SecondHotelProject.Models.Abstract
{
    public class MiniBarItem
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        public MiniBarItem(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            return obj is MiniBarItem item &&
                   Name == item.Name &&
                   Price == item.Price;
        }
    }
}
