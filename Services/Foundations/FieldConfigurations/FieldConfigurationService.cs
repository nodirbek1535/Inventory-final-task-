using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Models.FieldConfigurations;

namespace Inventory_final_task_.Services.Foundations.FieldConfigurations
{
    public partial class FieldConfigurationService : IFieldConfigurationService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public FieldConfigurationService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<FieldConfiguration> AddFieldConfigurationAsync(FieldConfiguration fieldConfiguration) =>
            this.storageBroker.InsertFieldConfigurationAsync(fieldConfiguration);

        public IQueryable<FieldConfiguration> RetrieveAllFieldConfigurations() =>
            this.storageBroker.SelectAllFieldConfigurations();

        public ValueTask<FieldConfiguration> RetrieveFieldConfigurationByIdAsync(Guid fieldConfigurationId) =>
            this.storageBroker.SelectFieldConfigurationByIdAsync(fieldConfigurationId);

        public ValueTask<FieldConfiguration> ModifyFieldConfigurationAsync(FieldConfiguration fieldConfiguration) =>
            this.storageBroker.UpdateFieldConfigurationAsync(fieldConfiguration);

        public ValueTask<FieldConfiguration> RemoveFieldConfigurationByIdAsync(Guid fieldConfigurationId) =>
            this.storageBroker.DeleteFieldConfigurationAsync(new FieldConfiguration { Id = fieldConfigurationId });
    }
}
