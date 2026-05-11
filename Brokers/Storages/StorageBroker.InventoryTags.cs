using Microsoft.EntityFrameworkCore;
using Inventory_final_task_.Models.InventoryTags;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<InventoryTag> InventoryTags { get; set; }

        public async ValueTask<InventoryTag> InsertInventoryTagAsync(InventoryTag inventoryTag)
        {
            this.InventoryTags.Add(inventoryTag);
            await this.SaveChangesAsync();

            return inventoryTag;
        }

        public IQueryable<InventoryTag> SelectAllInventoryTags() =>
            this.SelectAll<InventoryTag>();

        public async ValueTask<InventoryTag> SelectInventoryTagByIdAsync(Guid inventoryTagId) =>
            await this.InventoryTags.FindAsync(inventoryTagId);

        public async ValueTask<InventoryTag> UpdateInventoryTagAsync(InventoryTag inventoryTag)
        {
            this.InventoryTags.Update(inventoryTag);
            await this.SaveChangesAsync();

            return inventoryTag;
        }

        public async ValueTask<InventoryTag> DeleteInventoryTagAsync(InventoryTag inventoryTag)
        {
            this.InventoryTags.Remove(inventoryTag);
            await this.SaveChangesAsync();

            return inventoryTag;
        }
    }
}
