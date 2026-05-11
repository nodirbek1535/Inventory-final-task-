using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Models.Tags;

namespace Inventory_final_task_.Services.Foundations.Tags
{
    public partial class TagService : ITagService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public TagService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Tag> AddTagAsync(Tag tag) =>
            this.storageBroker.InsertTagAsync(tag);

        public IQueryable<Tag> RetrieveAllTags() =>
            this.storageBroker.SelectAllTags();

        public ValueTask<Tag> RetrieveTagByIdAsync(Guid tagId) =>
            this.storageBroker.SelectTagByIdAsync(tagId);

        public ValueTask<Tag> ModifyTagAsync(Tag tag) =>
            this.storageBroker.UpdateTagAsync(tag);

        public ValueTask<Tag> RemoveTagByIdAsync(Guid tagId) =>
            this.storageBroker.DeleteTagAsync(new Tag { Id = tagId });
    }
}
