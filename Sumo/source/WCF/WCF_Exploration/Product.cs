namespace WCF_Exploration
{
    public class Product
    {
        
        public Product(int id, string name, Money unitPrice)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Money UnitPrice { get; set; }
    }
}