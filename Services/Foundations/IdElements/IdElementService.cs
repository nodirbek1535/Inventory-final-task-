using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Models.IdElements;

namespace Inventory_final_task_.Services.Foundations.IdElements
{
    public partial class IdElementService : IIdElementService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public IdElementService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<IdElement> AddIdElementAsync(IdElement idElement) =>
            this.storageBroker.InsertIdElementAsync(idElement);

        public IQueryable<IdElement> RetrieveAllIdElements() =>
            this.storageBroker.SelectAllIdElements();

        public ValueTask<IdElement> RetrieveIdElementByIdAsync(Guid idElementId) =>
            this.storageBroker.SelectIdElementByIdAsync(idElementId);

        public ValueTask<IdElement> ModifyIdElementAsync(IdElement idElement) =>
            this.storageBroker.UpdateIdElementAsync(idElement);

        public ValueTask<IdElement> RemoveIdElementByIdAsync(Guid idElementId) =>
            this.storageBroker.DeleteIdElementAsync(new IdElement { Id = idElementId });
    }
}
