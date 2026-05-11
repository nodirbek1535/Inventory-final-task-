using Inventory_final_task_.Models.Likes;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Like> InsertLikeAsync(Like like);
        IQueryable<Like> SelectAllLikes();
        ValueTask<Like> SelectLikeByIdAsync(Guid likeId);
        ValueTask<Like> DeleteLikeAsync(Like like);
    }
}
