using Inventory_final_task_.Models.InventoryTags;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<InventoryTag> InsertInventoryTagAsync(InventoryTag inventoryTag);
        IQueryable<InventoryTag> SelectAllInventoryTags();
        ValueTask<InventoryTag> SelectInventoryTagByIdAsync(Guid inventoryTagId);
        ValueTask<InventoryTag> UpdateInventoryTagAsync(InventoryTag inventoryTag);
        ValueTask<InventoryTag> DeleteInventoryTagAsync(InventoryTag inventoryTag);
    }
}
