using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Models.Comments;

namespace Inventory_final_task_.Services.Foundations.Comments
{
    public partial class CommentService : ICommentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public CommentService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Comment> AddCommentAsync(Comment comment) =>
            this.storageBroker.InsertCommentAsync(comment);

        public IQueryable<Comment> RetrieveAllComments() =>
            this.storageBroker.SelectAllComments();

        public ValueTask<Comment> RetrieveCommentByIdAsync(Guid commentId) =>
            this.storageBroker.SelectCommentByIdAsync(commentId);

        public ValueTask<Comment> ModifyCommentAsync(Comment comment) =>
            this.storageBroker.UpdateCommentAsync(comment);

        public ValueTask<Comment> RemoveCommentByIdAsync(Guid commentId) =>
            this.storageBroker.DeleteCommentAsync(new Comment { Id = commentId });
    }
}
