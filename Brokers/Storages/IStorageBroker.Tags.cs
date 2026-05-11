//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Tags;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Tag> InsertTagAsync(Tag tag);
        IQueryable<Tag> SelectAllTags();
        ValueTask<Tag> SelectTagByIdAsync(Guid tagId);
        ValueTask<Tag> UpdateTagAsync(Tag tag);
        ValueTask<Tag> DeleteTagAsync(Tag tag);
    }
}
