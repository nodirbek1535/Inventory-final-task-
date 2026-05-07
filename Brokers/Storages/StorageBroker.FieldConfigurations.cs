//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.FieldConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<FieldConfiguration> FieldConfigurations { get; set; }

        public async ValueTask<FieldConfiguration> InsertFieldConfigurationAsync(FieldConfiguration fieldConfiguration)
        {
            this.FieldConfigurations.Add(fieldConfiguration);
            await this.SaveChangesAsync();

            return fieldConfiguration;
        }

        public IQueryable<FieldConfiguration> SelectAllFieldConfigurations() =>
            this.SelectAll<FieldConfiguration>();

        public async ValueTask<FieldConfiguration> SelectFieldConfigurationByIdAsync(Guid fieldConfigurationId) =>
            await this.FieldConfigurations.FindAsync(fieldConfigurationId); 

        public async ValueTask<FieldConfiguration> UpdateFieldConfigurationAsync(FieldConfiguration fieldConfiguration)
        {
            this.FieldConfigurations.Update(fieldConfiguration);
            await this.SaveChangesAsync();

            return fieldConfiguration;
        }

        public async ValueTask<FieldConfiguration> DeleteFieldConfigurationAsync(FieldConfiguration fieldConfiguration)
        {
            this.FieldConfigurations.Remove(fieldConfiguration);
            await this.SaveChangesAsync();

            return fieldConfiguration;
        }
    }
}
