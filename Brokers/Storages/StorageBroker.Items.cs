using Microsoft.EntityFrameworkCore;
using Inventory_final_task_.Models.Items;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Item> Items { get; set; }

        public async ValueTask<Item> InsertItemAsync(Item item)
        {
            this.Items.Add(item);
            await this.SaveChangesAsync();

            return item;
        }

        public IQueryable<Item> SelectAllItems() =>
            this.SelectAll<Item>();

        public async ValueTask<Item> SelectItemByIdAsync(Guid itemId) =>
            await this.Items.FindAsync(itemId);

        public async ValueTask<Item> UpdateItemAsync(Item item)
        {
            this.Items.Update(item);
            await this.SaveChangesAsync();

            return item;
        }

        public async ValueTask<Item> DeleteItemAsync(Item item)
        {
            this.Items.Remove(item);
            await this.SaveChangesAsync();

            return item;
        }
    }
}
