using Inventory_final_task_.Models.InventoryTags;

namespace Inventory_final_task_.Services.Foundations.InventoryTags
{
    public interface IInventoryTagService
    {
        ValueTask<InventoryTag> AddInventoryTagAsync(InventoryTag inventoryTag);
        IQueryable<InventoryTag> RetrieveAllInventoryTags();
        ValueTask<InventoryTag> RetrieveInventoryTagByIdAsync(Guid inventoryTagId);
        ValueTask<InventoryTag> ModifyInventoryTagAsync(InventoryTag inventoryTag);
        ValueTask<InventoryTag> RemoveInventoryTagByIdAsync(Guid inventoryTagId);
    }
}
