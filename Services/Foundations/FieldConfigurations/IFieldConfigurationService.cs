using Inventory_final_task_.Models.FieldConfigurations;

namespace Inventory_final_task_.Services.Foundations.FieldConfigurations
{
    public interface IFieldConfigurationService
    {
        ValueTask<FieldConfiguration> AddFieldConfigurationAsync(FieldConfiguration fieldConfiguration);
        IQueryable<FieldConfiguration> RetrieveAllFieldConfigurations();
        ValueTask<FieldConfiguration> RetrieveFieldConfigurationByIdAsync(Guid fieldConfigurationId);
        ValueTask<FieldConfiguration> ModifyFieldConfigurationAsync(FieldConfiguration fieldConfiguration);
        ValueTask<FieldConfiguration> RemoveFieldConfigurationByIdAsync(Guid fieldConfigurationId);
    }
}
