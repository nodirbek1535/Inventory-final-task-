//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker : DbContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration) =>
            this.configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                this.configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);

            optionsBuilder.UseExceptionProcessor();
        }

        protected IQueryable<T> SelectAll<T>() where T : class => this.Set<T>();

        public override void Dispose() { }
    }
}
