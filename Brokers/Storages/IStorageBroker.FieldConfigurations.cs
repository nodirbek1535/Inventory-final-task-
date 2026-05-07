//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.FieldConfigurations;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<FieldConfiguration> InsertFieldConfigurationAsync(FieldConfiguration fieldConfiguration);
        IQueryable<FieldConfiguration> SelectAllFieldConfigurations();
        ValueTask<FieldConfiguration> SelectFieldConfigurationByIdAsync(Guid fieldConfigurationId);
        ValueTask<FieldConfiguration> UpdateFieldConfigurationAsync(FieldConfiguration fieldConfiguration);
        ValueTask<FieldConfiguration> DeleteFieldConfigurationAsync(FieldConfiguration fieldConfiguration);
    }
}
