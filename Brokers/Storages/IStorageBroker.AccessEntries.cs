using Inventory_final_task_.Models.AccessEntries;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<AccessEntry> InsertAccessEntryAsync(AccessEntry accessEntry);
        IQueryable<AccessEntry> SelectAllAccessEntries();
        ValueTask<AccessEntry> SelectAccessEntryByIdAsync(Guid accessEntryId);
        ValueTask<AccessEntry> UpdateAccessEntryAsync(AccessEntry accessEntry);
        ValueTask<AccessEntry> DeleteAccessEntryAsync(AccessEntry accessEntry);
    }
}
