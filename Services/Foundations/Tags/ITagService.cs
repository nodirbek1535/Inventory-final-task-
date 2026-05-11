using Inventory_final_task_.Models.Tags;

namespace Inventory_final_task_.Services.Foundations.Tags
{
    public interface ITagService
    {
        ValueTask<Tag> AddTagAsync(Tag tag);
        IQueryable<Tag> RetrieveAllTags();
        ValueTask<Tag> RetrieveTagByIdAsync(Guid tagId);
        ValueTask<Tag> ModifyTagAsync(Tag tag);
        ValueTask<Tag> RemoveTagByIdAsync(Guid tagId);
    }
}
