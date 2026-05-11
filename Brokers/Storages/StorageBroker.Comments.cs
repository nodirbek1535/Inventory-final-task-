using Microsoft.EntityFrameworkCore;
using Inventory_final_task_.Models.Comments;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Comment> Comments { get; set; }

        public async ValueTask<Comment> InsertCommentAsync(Comment comment)
        {
            this.Comments.Add(comment);
            await this.SaveChangesAsync();

            return comment;
        }

        public IQueryable<Comment> SelectAllComments() =>
            this.SelectAll<Comment>();

        public async ValueTask<Comment> SelectCommentByIdAsync(Guid commentId) =>
            await this.Comments.FindAsync(commentId);

        public async ValueTask<Comment> UpdateCommentAsync(Comment comment)
        {
            this.Comments.Update(comment);
            await this.SaveChangesAsync();

            return comment;
        }

        public async ValueTask<Comment> DeleteCommentAsync(Comment comment)
        {
            this.Comments.Remove(comment);
            await this.SaveChangesAsync();

            return comment;
        }
    }
}
