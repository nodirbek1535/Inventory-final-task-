using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Models.AccessEntries;

namespace Inventory_final_task_.Services.Foundations.AccessEntries
{
    public partial class AccessEntryService : IAccessEntryService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public AccessEntryService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<AccessEntry> AddAccessEntryAsync(AccessEntry accessEntry) =>
            this.storageBroker.InsertAccessEntryAsync(accessEntry);

        public IQueryable<AccessEntry> RetrieveAllAccessEntries() =>
            this.storageBroker.SelectAllAccessEntries();

        public ValueTask<AccessEntry> RetrieveAccessEntryByIdAsync(Guid accessEntryId) =>
            this.storageBroker.SelectAccessEntryByIdAsync(accessEntryId);

        public ValueTask<AccessEntry> ModifyAccessEntryAsync(AccessEntry accessEntry) =>
            this.storageBroker.UpdateAccessEntryAsync(accessEntry);

        public ValueTask<AccessEntry> RemoveAccessEntryByIdAsync(Guid accessEntryId) =>
            this.storageBroker.DeleteAccessEntryAsync(new AccessEntry { Id = accessEntryId });
    }
}
