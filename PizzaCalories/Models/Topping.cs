using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2.0;
        private const double MinWeight = 1;
        private const double MaxWeight = 50;
        private string type;
        //private double modifier;
        private double caloriesPerGram;
        private double grams;
        private Dictionary<string, double> toppingTypes = new()
        {
            { "meat", 1.2},
            {"veggies", 0.8 },
            {"cheese", 1.1},
            {"sauce", 0.9 }

        };


        public Topping(string type, double grams)
        {
            Type = type;
            Grams = grams;
            CaloriesPerGram = BaseCaloriesPerGram *  toppingTypes[Type.ToLower()];
        }

        public string Type
        {
            get => type;
            private set
            {
                if (!toppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;   
            }
        }

        public double Grams
        {
            get => grams;
            set
            {
                if(value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                grams = value;
            }
        }

        public double CaloriesPerGram
        {
            get => caloriesPerGram;
            set => caloriesPerGram = value;
        }

        public double Calories => Grams * CaloriesPerGram;
    }
}
