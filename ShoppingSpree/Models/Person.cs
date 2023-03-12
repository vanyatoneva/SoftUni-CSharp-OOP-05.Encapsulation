using System.Text;
using static ShoppingSpree.Validate;



namespace ShoppingSpree.Models { 
    public class Person
    {
        private string name;
        private decimal money;
        public Person(string name, decimal money)
        {
            
            Name = name;
            Money = money;
            Products = new();
        }

        public string Name {
            get => name;
            private set
            {
                ValidateName(value);
                name = value;
            }
        }
        public decimal Money { 
            get => money;
             private set {
                ValidateMoney(value);
                money = value;
            }
         }
        private List<Product> Products;

        public string BuyProduct(Product product) 
        {
            if(product.Cost > Money)
            {
                return $"{Name} can't afford {product.Name}";
                
            }

            Money -= product.Cost;
            Products.Add(product);
            return $"{Name} bought {product.Name}";
        }

        public override string ToString()
        {

            StringBuilder sb = new();
            sb.Append($"{Name} - ");
            if (Products.Any())
            {
                string products = String.Join(", ", Products);
                sb.Append(products);
            }
            else
            {
                sb.Append("Nothing bought");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
