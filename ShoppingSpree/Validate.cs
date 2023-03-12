using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public static class Validate
    {
        public static void ValidateName(string name)
        {
            if(String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }

        public static void ValidateMoney(decimal money)
        {
            if(money < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }
    }
}
