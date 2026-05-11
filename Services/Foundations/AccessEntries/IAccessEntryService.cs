using Inventory_final_task_.Models.AccessEntries;

namespace Inventory_final_task_.Services.Foundations.AccessEntries
{
    public interface IAccessEntryService
    {
        ValueTask<AccessEntry> AddAccessEntryAsync(AccessEntry accessEntry);
        IQueryable<AccessEntry> RetrieveAllAccessEntries();
        ValueTask<AccessEntry> RetrieveAccessEntryByIdAsync(Guid accessEntryId);
        ValueTask<AccessEntry> ModifyAccessEntryAsync(AccessEntry accessEntry);
        ValueTask<AccessEntry> RemoveAccessEntryByIdAsync(Guid accessEntryId);
    }
}
