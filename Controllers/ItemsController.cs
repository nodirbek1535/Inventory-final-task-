using Microsoft.AspNetCore.Mvc;
using Inventory_final_task_.Models.Items;
using Inventory_final_task_.Services.Foundations.Items;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : RESTFulController
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService) =>
            this.itemService = itemService;

        [HttpPost]
        public async ValueTask<ActionResult<Item>> PostItemAsync(Item item)
        {
            Item addedItem = await this.itemService.AddItemAsync(item);

            return Created(addedItem);
        }

        [HttpGet]
        public ActionResult<IQueryable<Item>> GetAllItems()
        {
            IQueryable<Item> allItems = this.itemService.RetrieveAllItems();

            return Ok(allItems);
        }

        [HttpGet("{itemId}")]
        public async ValueTask<ActionResult<Item>> GetItemByIdAsync(Guid itemId)
        {
            Item item = await this.itemService.RetrieveItemByIdAsync(itemId);

            return Ok(item);
        }

        [HttpPut]
        public async ValueTask<ActionResult<Item>> PutItemAsync(Item item)
        {
            Item modifiedItem = await this.itemService.ModifyItemAsync(item);

            return Ok(modifiedItem);
        }

        [HttpDelete("{itemId}")]
        public async ValueTask<ActionResult<Item>> DeleteItemByIdAsync(Guid itemId)
        {
            Item removedItem = await this.itemService.RemoveItemByIdAsync(itemId);

            return Ok(removedItem);
        }
    }
}
