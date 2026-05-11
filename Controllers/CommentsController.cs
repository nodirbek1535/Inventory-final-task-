using Microsoft.AspNetCore.Mvc;
using Inventory_final_task_.Models.Comments;
using Inventory_final_task_.Services.Foundations.Comments;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : RESTFulController
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService) =>
            this.commentService = commentService;

        [HttpPost]
        public async ValueTask<ActionResult<Comment>> PostCommentAsync(Comment comment)
        {
            Comment addedComment = await this.commentService.AddCommentAsync(comment);

            return Created(addedComment);
        }

        [HttpGet]
        public ActionResult<IQueryable<Comment>> GetAllComments()
        {
            IQueryable<Comment> allComments = this.commentService.RetrieveAllComments();

            return Ok(allComments);
        }

        [HttpGet("{commentId}")]
        public async ValueTask<ActionResult<Comment>> GetCommentByIdAsync(Guid commentId)
        {
            Comment comment = await this.commentService.RetrieveCommentByIdAsync(commentId);

            return Ok(comment);
        }

        [HttpPut]
        public async ValueTask<ActionResult<Comment>> PutCommentAsync(Comment comment)
        {
            Comment modifiedComment = await this.commentService.ModifyCommentAsync(comment);

            return Ok(modifiedComment);
        }

        [HttpDelete("{commentId}")]
        public async ValueTask<ActionResult<Comment>> DeleteCommentByIdAsync(Guid commentId)
        {
            Comment removedComment = await this.commentService.RemoveCommentByIdAsync(commentId);

            return Ok(removedComment);
        }
    }
}
