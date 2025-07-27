namespace DelegatesEventsConsoleApp.Models;

public class Product
{
    public string ItemName { get; }
    public float Price { get; }

    public Product(string itemName, float price)
    {
        ItemName = itemName;
        Price = price;
    }
}