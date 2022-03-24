namespace TestApi.Models;

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Color { get; set; }

    public enum Collor
    {
        White,
        Black,
        Pumpkin
    }

    public Item() { }

    public Item(string name, string description, double price, Collor color)
    {
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.Color = color.ToString();
    }
}
