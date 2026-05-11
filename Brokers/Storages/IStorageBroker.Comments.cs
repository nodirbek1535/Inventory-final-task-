using Inventory_final_task_.Models.Comments;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Comment> InsertCommentAsync(Comment comment);
        IQueryable<Comment> SelectAllComments();
        ValueTask<Comment> SelectCommentByIdAsync(Guid commentId);
        ValueTask<Comment> UpdateCommentAsync(Comment comment);
        ValueTask<Comment> DeleteCommentAsync(Comment comment);
    }
}
