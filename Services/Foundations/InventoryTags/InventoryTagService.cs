using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Models.InventoryTags;

namespace Inventory_final_task_.Services.Foundations.InventoryTags
{
    public partial class InventoryTagService : IInventoryTagService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public InventoryTagService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<InventoryTag> AddInventoryTagAsync(InventoryTag inventoryTag) =>
            this.storageBroker.InsertInventoryTagAsync(inventoryTag);

        public IQueryable<InventoryTag> RetrieveAllInventoryTags() =>
            this.storageBroker.SelectAllInventoryTags();

        public ValueTask<InventoryTag> RetrieveInventoryTagByIdAsync(Guid inventoryTagId) =>
            this.storageBroker.SelectInventoryTagByIdAsync(inventoryTagId);

        public ValueTask<InventoryTag> ModifyInventoryTagAsync(InventoryTag inventoryTag) =>
            this.storageBroker.UpdateInventoryTagAsync(inventoryTag);

        public ValueTask<InventoryTag> RemoveInventoryTagByIdAsync(Guid inventoryTagId) =>
            this.storageBroker.DeleteInventoryTagAsync(new InventoryTag { Id = inventoryTagId });
    }
}
