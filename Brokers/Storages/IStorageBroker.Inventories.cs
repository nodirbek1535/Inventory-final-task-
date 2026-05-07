//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Inventories;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Inventory> InsertInventoryAsync(Inventory inventory);
        IQueryable<Inventory> SelectAllInventories();
        ValueTask<Inventory> SelectInventoryByIdAsync(Guid inventoryId);
        ValueTask<Inventory> UpdateInventoryAsync(Inventory inventory);
        ValueTask<Inventory> DeleteInventoryAsync(Inventory inventory);
    }
}
