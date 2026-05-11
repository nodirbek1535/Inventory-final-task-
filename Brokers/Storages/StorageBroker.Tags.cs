//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Microsoft.EntityFrameworkCore;
using Inventory_final_task_.Models.Tags;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Tag> Tags { get; set; }

        public async ValueTask<Tag> InsertTagAsync(Tag tag)
        {
            this.Tags.Add(tag);
            await this.SaveChangesAsync();

            return tag;
        }

        public IQueryable<Tag> SelectAllTags() =>
            this.SelectAll<Tag>();

        public async ValueTask<Tag> SelectTagByIdAsync(Guid tagId) =>
            await this.Tags.FindAsync(tagId);

        public async ValueTask<Tag> UpdateTagAsync(Tag tag)
        {
            this.Tags.Update(tag);
            await this.SaveChangesAsync();

            return tag;
        }

        public async ValueTask<Tag> DeleteTagAsync(Tag tag)
        {
            this.Tags.Remove(tag);
            await this.SaveChangesAsync();

            return tag;
        }
    }
}
