using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Models.Inventories;

namespace Inventory_final_task_.Services.Foundations.Inventories
{
    public partial class InventoryService : IInventoryService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public InventoryService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Inventory> AddInventoryAsync(Inventory inventory) =>
            this.storageBroker.InsertInventoryAsync(inventory);

        public IQueryable<Inventory> RetrieveAllInventories() =>
            this.storageBroker.SelectAllInventories();

        public ValueTask<Inventory> RetrieveInventoryByIdAsync(Guid inventoryId) =>
            this.storageBroker.SelectInventoryByIdAsync(inventoryId);

        public ValueTask<Inventory> ModifyInventoryAsync(Inventory inventory) =>
            this.storageBroker.UpdateInventoryAsync(inventory);

        public ValueTask<Inventory> RemoveInventoryByIdAsync(Guid inventoryId) =>
            this.storageBroker.DeleteInventoryAsync(new Inventory { Id = inventoryId });
    }
}
