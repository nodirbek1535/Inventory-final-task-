using Microsoft.AspNetCore.Mvc;
using Inventory_final_task_.Models.Likes;
using Inventory_final_task_.Services.Foundations.Likes;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : RESTFulController
    {
        private readonly ILikeService likeService;

        public LikesController(ILikeService likeService) =>
            this.likeService = likeService;

        [HttpPost]
        public async ValueTask<ActionResult<Like>> PostLikeAsync(Like like)
        {
            Like addedLike = await this.likeService.AddLikeAsync(like);

            return Created(addedLike);
        }

        [HttpGet]
        public ActionResult<IQueryable<Like>> GetAllLikes()
        {
            IQueryable<Like> allLikes = this.likeService.RetrieveAllLikes();

            return Ok(allLikes);
        }

        [HttpGet("{likeId}")]
        public async ValueTask<ActionResult<Like>> GetLikeByIdAsync(Guid likeId)
        {
            Like like = await this.likeService.RetrieveLikeByIdAsync(likeId);

            return Ok(like);
        }

        [HttpDelete("{likeId}")]
        public async ValueTask<ActionResult<Like>> DeleteLikeByIdAsync(Guid likeId)
        {
            Like removedLike = await this.likeService.RemoveLikeByIdAsync(likeId);

            return Ok(removedLike);
        }
    }
}
