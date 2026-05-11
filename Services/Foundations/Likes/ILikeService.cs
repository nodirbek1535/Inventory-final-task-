using Inventory_final_task_.Models.Likes;

namespace Inventory_final_task_.Services.Foundations.Likes
{
    public interface ILikeService
    {
        ValueTask<Like> AddLikeAsync(Like like);
        IQueryable<Like> RetrieveAllLikes();
        ValueTask<Like> RetrieveLikeByIdAsync(Guid likeId);
        ValueTask<Like> RemoveLikeByIdAsync(Guid likeId);
    }
}
