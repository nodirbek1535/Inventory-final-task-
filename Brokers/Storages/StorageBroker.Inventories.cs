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
            using var broker = new StorageBroker(this.configuration);
            broker.Inventories.Add(inventory);
            await broker.SaveChangesAsync();

            return inventory;
        }

        public IQueryable<Inventory> SelectAllInventories() =>
            this.SelectAll<Inventory>();

        public async ValueTask<Inventory> SelectInventoryByIdAsync(Guid inventoryId)
        {
            using var broker = new StorageBroker(this.configuration);

            return await broker.Inventories
                .FirstOrDefaultAsync(inv => inv.Id == inventoryId);
        }

        public async ValueTask<Inventory> UpdateInventoryAsync(Inventory inventory)
        {
            using var broker = new StorageBroker(this.configuration);
            broker.Inventories.Update(inventory);
            await broker.SaveChangesAsync();

            return inventory;
        }

        public async ValueTask<Inventory> DeleteInventoryAsync(Inventory inventory)
        {
            using var broker = new StorageBroker(this.configuration);
            broker.Inventories.Remove(inventory);
            await broker.SaveChangesAsync();

            return inventory;
        }
    }
}
