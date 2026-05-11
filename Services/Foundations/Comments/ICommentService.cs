using Inventory_final_task_.Models.Comments;

namespace Inventory_final_task_.Services.Foundations.Comments
{
    public interface ICommentService
    {
        ValueTask<Comment> AddCommentAsync(Comment comment);
        IQueryable<Comment> RetrieveAllComments();
        ValueTask<Comment> RetrieveCommentByIdAsync(Guid commentId);
        ValueTask<Comment> ModifyCommentAsync(Comment comment);
        ValueTask<Comment> RemoveCommentByIdAsync(Guid commentId);
    }
}
