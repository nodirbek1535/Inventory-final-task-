using Inventory_final_task_.Models.Items;

namespace Inventory_final_task_.Services.Foundations.Items
{
    public interface IItemService
    {
        ValueTask<Item> AddItemAsync(Item item);
        IQueryable<Item> RetrieveAllItems();
        ValueTask<Item> RetrieveItemByIdAsync(Guid itemId);
        ValueTask<Item> ModifyItemAsync(Item item);
        ValueTask<Item> RemoveItemByIdAsync(Guid itemId);
    }
}
