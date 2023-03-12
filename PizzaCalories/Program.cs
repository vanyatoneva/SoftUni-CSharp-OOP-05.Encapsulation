

using PizzaCalories.Models;

try
{
    string[] pizzaInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if(pizzaInfo.Length < 2)
    {
        Pizza pizzaNull = new(null);
    }
    Pizza pizza = new(pizzaInfo[1]);
    
    string[] doughtInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    Dough dough = new(doughtInfo[1], doughtInfo[2], double.Parse(doughtInfo[3]));
    pizza.Dough = dough;
    string[] toppingInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    while (toppingInfo[0] != "END")
    {
        Topping toppiny = new(toppingInfo[1], double.Parse(toppingInfo[2]));
        pizza.AddTopping(toppiny);
        toppingInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    }
    Console.WriteLine(pizza.ToString());
}
catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
