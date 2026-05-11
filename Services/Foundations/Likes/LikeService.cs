using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Models.Likes;

namespace Inventory_final_task_.Services.Foundations.Likes
{
    public partial class LikeService : ILikeService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public LikeService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Like> AddLikeAsync(Like like) =>
            this.storageBroker.InsertLikeAsync(like);

        public IQueryable<Like> RetrieveAllLikes() =>
            this.storageBroker.SelectAllLikes();

        public ValueTask<Like> RetrieveLikeByIdAsync(Guid likeId) =>
            this.storageBroker.SelectLikeByIdAsync(likeId);

        public ValueTask<Like> RemoveLikeByIdAsync(Guid likeId) =>
            this.storageBroker.DeleteLikeAsync(new Like { Id = likeId });
    }
}
