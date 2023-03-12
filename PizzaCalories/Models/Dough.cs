using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2.0;
        private const double MiniWeight = 1;
        private const double MaxWeight = 200;
        private Dictionary<string, double> flourTypes = new()
        {
            { "white", 1.5},
            {"wholegrain", 1.0 }
        };

        private Dictionary<string, double> bakingTypes = new()
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0}
        };

        private string flourType;
        private string bakingType;
        private double grams;
        private double modifier;
        private double caloriesPerGram;

        public Dough(string flourType, string bakingType, double grams)
        {
            FlourType = flourType;
            BakingType = bakingType;
            Gram = grams;
            Modifier = BaseCaloriesPerGram * bakingTypes[BakingType.ToLower()] * flourTypes[FlourType.ToLower()];
            CaloriesPerGram = Modifier;
        }

        public string BakingType
        {
            get => bakingType;
            private set
            {
                if (!bakingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }
                bakingType = value;
            }
        }
        public string FlourType
        {
            get => flourType;
            private set
            {
                if (!flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public double Gram
        {
            get => grams;
            private set
            {
                if(value < MiniWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MiniWeight}..{MaxWeight}].");
                }
                grams = value;
            }
        }

        public double Modifier
        {
            get => modifier;
            private set
            {
                modifier = value; //bakingTypes[bakingType] * flourTypes[flourType];
            }
        }

        public double CaloriesPerGram
        {
            get => caloriesPerGram;
            private set => caloriesPerGram = value;
        }

        public double Calories => Gram * caloriesPerGram;
    }
}
