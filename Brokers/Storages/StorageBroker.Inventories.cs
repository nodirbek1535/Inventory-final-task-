//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Inventories;
using Microsoft.EntityFrameworkCore;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Inventory> Inventories { get; set; }

        public async ValueTask<Inventory> InsertInventoryAsync(Inventory inventory)
        {
            this.Inventories.Add(inventory);
            await this.SaveChangesAsync();

            return inventory;
        }

        public IQueryable<Inventory> SelectAllInventories() =>
            this.SelectAll<Inventory>();

        public async ValueTask<Inventory> SelectInventoryByIdAsync(Guid inventoryId) =>
            await this.Inventories.FindAsync(inventoryId);

        public async ValueTask<Inventory> UpdateInventoryAsync(Inventory inventory)
        {
            this.Inventories.Update(inventory);
            await this.SaveChangesAsync();

            return inventory;
        }

        public async ValueTask<Inventory> DeleteInventoryAsync(Inventory inventory)
        {
            this.Inventories.Remove(inventory);
            await this.SaveChangesAsync();

            return inventory;
        }
    }
}
