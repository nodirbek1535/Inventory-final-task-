using Inventory_final_task_.Models.Inventories;

namespace Inventory_final_task_.Services.Foundations.Inventories
{
    public interface IInventoryService
    {
        ValueTask<Inventory> AddInventoryAsync(Inventory inventory);
        IQueryable<Inventory> RetrieveAllInventories();
        ValueTask<Inventory> RetrieveInventoryByIdAsync(Guid inventoryId);
        ValueTask<Inventory> ModifyInventoryAsync(Inventory inventory);
        ValueTask<Inventory> RemoveInventoryByIdAsync(Guid inventoryId);
    }
}
