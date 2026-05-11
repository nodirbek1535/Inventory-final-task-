using Microsoft.AspNetCore.Mvc;
using Inventory_final_task_.Models.InventoryTags;
using Inventory_final_task_.Services.Foundations.InventoryTags;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryTagsController : RESTFulController
    {
        private readonly IInventoryTagService inventoryTagService;

        public InventoryTagsController(IInventoryTagService inventoryTagService) =>
            this.inventoryTagService = inventoryTagService;

        [HttpPost]
        public async ValueTask<ActionResult<InventoryTag>> PostInventoryTagAsync(InventoryTag inventoryTag)
        {
            InventoryTag addedInventoryTag = await this.inventoryTagService.AddInventoryTagAsync(inventoryTag);

            return Created(addedInventoryTag);
        }

        [HttpGet]
        public ActionResult<IQueryable<InventoryTag>> GetAllInventoryTags()
        {
            IQueryable<InventoryTag> allInventoryTags = this.inventoryTagService.RetrieveAllInventoryTags();

            return Ok(allInventoryTags);
        }

        [HttpGet("{inventoryTagId}")]
        public async ValueTask<ActionResult<InventoryTag>> GetInventoryTagByIdAsync(Guid inventoryTagId)
        {
            InventoryTag inventoryTag = await this.inventoryTagService.RetrieveInventoryTagByIdAsync(inventoryTagId);

            return Ok(inventoryTag);
        }

        [HttpPut]
        public async ValueTask<ActionResult<InventoryTag>> PutInventoryTagAsync(InventoryTag inventoryTag)
        {
            InventoryTag modifiedInventoryTag = await this.inventoryTagService.ModifyInventoryTagAsync(inventoryTag);

            return Ok(modifiedInventoryTag);
        }

        [HttpDelete("{inventoryTagId}")]
        public async ValueTask<ActionResult<InventoryTag>> DeleteInventoryTagByIdAsync(Guid inventoryTagId)
        {
            InventoryTag removedInventoryTag = await this.inventoryTagService.RemoveInventoryTagByIdAsync(inventoryTagId);

            return Ok(removedInventoryTag);
        }
    }
}
