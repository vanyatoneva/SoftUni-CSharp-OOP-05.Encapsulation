using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    
    public class Pizza
    {

        private const int MinLengthOfName = 1;
        private const int MaxLengthOfName = 15;
        private const int MaxToppings = 10;

        private string name;
        private Dough dough;

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }
        public string Name {
            get => name;
            set
            {
                if(String.IsNullOrEmpty(value) ||value.Length < MinLengthOfName || value.Length > MaxLengthOfName)
                {
                    throw new ArgumentException($"Pizza name should be between {MinLengthOfName} and {MaxLengthOfName} symbols.");
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get => dough;
            set
            {
                if (value != null)
                {
                    dough = value;
                }
            }
        }
         public List<Topping> Toppings { get; private set; }


        public void AddTopping(Topping topping)
        {
            if(Toppings.Count == MaxToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaxToppings}].");
            }
            Toppings.Add(topping);
        }

        public double PizzaTotalCalories()
        {
            return Dough.Calories + Toppings.Sum(t => t.Calories);
        }

        public override string ToString()
        {
            return $"{Name} - {PizzaTotalCalories():f2} Calories.";
        }
    }
}
