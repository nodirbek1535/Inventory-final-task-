using Microsoft.EntityFrameworkCore;
using Inventory_final_task_.Models.AccessEntries;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<AccessEntry> AccessEntries { get; set; }

        public async ValueTask<AccessEntry> InsertAccessEntryAsync(AccessEntry accessEntry)
        {
            this.AccessEntries.Add(accessEntry);
            await this.SaveChangesAsync();

            return accessEntry;
        }

        public IQueryable<AccessEntry> SelectAllAccessEntries() =>
            this.SelectAll<AccessEntry>();

        public async ValueTask<AccessEntry> SelectAccessEntryByIdAsync(Guid accessEntryId) =>
            await this.AccessEntries.FindAsync(accessEntryId);

        public async ValueTask<AccessEntry> UpdateAccessEntryAsync(AccessEntry accessEntry)
        {
            this.AccessEntries.Update(accessEntry);
            await this.SaveChangesAsync();

            return accessEntry;
        }

        public async ValueTask<AccessEntry> DeleteAccessEntryAsync(AccessEntry accessEntry)
        {
            this.AccessEntries.Remove(accessEntry);
            await this.SaveChangesAsync();

            return accessEntry;
        }
    }
}
