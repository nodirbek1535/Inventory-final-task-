using Microsoft.AspNetCore.Mvc;
using Inventory_final_task_.Models.Tags;
using Inventory_final_task_.Services.Foundations.Tags;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : RESTFulController
    {
        private readonly ITagService tagService;

        public TagsController(ITagService tagService) =>
            this.tagService = tagService;

        [HttpPost]
        public async ValueTask<ActionResult<Tag>> PostTagAsync(Tag tag)
        {
            Tag addedTag = await this.tagService.AddTagAsync(tag);

            return Created(addedTag);
        }

        [HttpGet]
        public ActionResult<IQueryable<Tag>> GetAllTags()
        {
            IQueryable<Tag> allTags = this.tagService.RetrieveAllTags();

            return Ok(allTags);
        }

        [HttpGet("{tagId}")]
        public async ValueTask<ActionResult<Tag>> GetTagByIdAsync(Guid tagId)
        {
            Tag tag = await this.tagService.RetrieveTagByIdAsync(tagId);

            return Ok(tag);
        }

        [HttpPut]
        public async ValueTask<ActionResult<Tag>> PutTagAsync(Tag tag)
        {
            Tag modifiedTag = await this.tagService.ModifyTagAsync(tag);

            return Ok(modifiedTag);
        }

        [HttpDelete("{tagId}")]
        public async ValueTask<ActionResult<Tag>> DeleteTagByIdAsync(Guid tagId)
        {
            Tag removedTag = await this.tagService.RemoveTagByIdAsync(tagId);

            return Ok(removedTag);
        }
    }
}
