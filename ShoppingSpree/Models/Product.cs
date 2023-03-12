using static ShoppingSpree.Validate;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name {
            get => name;
            private set
            {
                ValidateName(value);
                name = value;
            } 
        }
        public decimal Cost {
            get => cost;    
            private set {
                ValidateMoney(value);
                cost = value;
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
