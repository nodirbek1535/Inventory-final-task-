//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.IdElements;
using Microsoft.EntityFrameworkCore;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<IdElement> IdElements { get; set; }

        public async ValueTask<IdElement> InsertIdElementAsync(IdElement idElement)
        {
            this.IdElements.Add(idElement);
            await this.SaveChangesAsync();

            return idElement;
        }

        public IQueryable<IdElement> SelectAllIdElements() =>
            this.SelectAll<IdElement>();

        public async ValueTask<IdElement> SelectIdElementByIdAsync(Guid idElementId) =>
            await this.IdElements.FindAsync(idElementId);

        public async ValueTask<IdElement> UpdateIdElementAsync(IdElement idElement)
        {
            this.IdElements.Update(idElement);
            await this.SaveChangesAsync();

            return idElement;
        }

        public async ValueTask<IdElement> DeleteIdElementAsync(IdElement idElement)
        {
            this.IdElements.Remove(idElement);
            await this.SaveChangesAsync();

            return idElement;
        }
    }
}
