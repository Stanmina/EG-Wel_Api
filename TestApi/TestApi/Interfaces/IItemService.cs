using TestApi.Models;

namespace TestApi.Interfaces;

public interface IItemService
{
    public List<Item> GetItems();
}
