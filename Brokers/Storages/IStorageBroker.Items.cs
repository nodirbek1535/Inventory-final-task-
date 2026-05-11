using Inventory_final_task_.Models.Items;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Item> InsertItemAsync(Item item);
        IQueryable<Item> SelectAllItems();
        ValueTask<Item> SelectItemByIdAsync(Guid itemId);
        ValueTask<Item> UpdateItemAsync(Item item);
        ValueTask<Item> DeleteItemAsync(Item item);
    }
}
