using Microsoft.EntityFrameworkCore;
using Inventory_final_task_.Models.Likes;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Like> Likes { get; set; }

        public async ValueTask<Like> InsertLikeAsync(Like like)
        {
            this.Likes.Add(like);
            await this.SaveChangesAsync();

            return like;
        }

        public IQueryable<Like> SelectAllLikes() =>
            this.SelectAll<Like>();

        public async ValueTask<Like> SelectLikeByIdAsync(Guid likeId) =>
            await this.Likes.FindAsync(likeId);

        public async ValueTask<Like> DeleteLikeAsync(Like like)
        {
            this.Likes.Remove(like);
            await this.SaveChangesAsync();

            return like;
        }
    }
}
