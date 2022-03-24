using TestApi.Interfaces;
using TestApi.Models;

namespace TestApi.Services;

public class InMemItemService : IItemService
{
    private List<Item> _items;

    public InMemItemService()
    {
        _items = new List<Item>()
        {
            new Item() { Name = "Terra Laptop Mid-End", Description = "15 Inch, Intel Core I7", Price = 750, Color = Item.Collor.Black.ToString() },
            new Item() { Name = "Terra Laptop High-End", Description = "17 Inch, Intel Core I9", Price = 1000, Color = Item.Collor.White.ToString() },

            new Item("Terra PC Mid-End", "Intel Core I7, GTX 1060", 1000, Item.Collor.Black ),
            new Item("Terra PC High-End", "Intel Core I7, RTX 2060", 1000, Item.Collor.Black)
        };
    }

    List<Item> IItemService.GetItems()
    {
        return _items;
    }
}