namespace SecondHotelProject
{
    public class Customer
    {
        public string CustomerName { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   CustomerName == customer.CustomerName;
        }
    }
}
