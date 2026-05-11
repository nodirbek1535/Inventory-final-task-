using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Models.Items;

namespace Inventory_final_task_.Services.Foundations.Items
{
    public partial class ItemService : IItemService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public ItemService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Item> AddItemAsync(Item item) =>
            this.storageBroker.InsertItemAsync(item);

        public IQueryable<Item> RetrieveAllItems() =>
            this.storageBroker.SelectAllItems();

        public ValueTask<Item> RetrieveItemByIdAsync(Guid itemId) =>
            this.storageBroker.SelectItemByIdAsync(itemId);

        public ValueTask<Item> ModifyItemAsync(Item item) =>
            this.storageBroker.UpdateItemAsync(item);

        public ValueTask<Item> RemoveItemByIdAsync(Guid itemId) =>
            this.storageBroker.DeleteItemAsync(new Item { Id = itemId });
    }
}
