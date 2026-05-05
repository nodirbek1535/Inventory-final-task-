//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Microsoft.EntityFrameworkCore;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker : DbContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = 
                this.configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }

        public override void Dispose() { }
    }
}
