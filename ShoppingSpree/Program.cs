using ShoppingSpree.Models;

string[] personsInput = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
string[] productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
List<Person> persons = new();
List<Product> products = new();

foreach(string person in personsInput)
{
    string[] personInfo = person.Split("=", StringSplitOptions.RemoveEmptyEntries);
    try
    {
        persons.Add(new(personInfo[0], decimal.Parse(personInfo[1])));
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

foreach (string product in productsInput)
{
    string[] productInfo = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
    try
    {
        products.Add(new(productInfo[0], decimal.Parse(productInfo[1])));
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

string command = Console.ReadLine();
while(command != "END")
{
    string[] values = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    //Console.WriteLine((persons.FirstOrDefault(person => person.Name == values[0])).BuyProduct(products.FirstOrDefault(prod => prod.Name == values[1])));
    Person buyer = persons.FirstOrDefault(person => person.Name == values[0]);
    Product productToBuy = products.FirstOrDefault(prod => prod.Name == values[1]);
    if(buyer != null && productToBuy != null)
    {
        Console.WriteLine(buyer.BuyProduct(productToBuy));
    }
    command = Console.ReadLine();   
}

foreach(Person person in persons)
{
    Console.WriteLine(person.ToString());
}