using Microsoft.AspNetCore.Mvc;
using Inventory_final_task_.Models.Inventories;
using Inventory_final_task_.Services.Foundations.Inventories;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoriesController : RESTFulController
    {
        private readonly IInventoryService inventoryService;

        public InventoriesController(IInventoryService inventoryService) =>
            this.inventoryService = inventoryService;

        [HttpPost]
        public async ValueTask<ActionResult<Inventory>> PostInventoryAsync(Inventory inventory)
        {
            Inventory addedInventory = await this.inventoryService.AddInventoryAsync(inventory);

            return Created(addedInventory);
        }

        [HttpGet]
        public ActionResult<IQueryable<Inventory>> GetAllInventories()
        {
            IQueryable<Inventory> allInventories = this.inventoryService.RetrieveAllInventories();

            return Ok(allInventories);
        }

        [HttpGet("{inventoryId}")]
        public async ValueTask<ActionResult<Inventory>> GetInventoryByIdAsync(Guid inventoryId)
        {
            Inventory inventory = await this.inventoryService.RetrieveInventoryByIdAsync(inventoryId);

            return Ok(inventory);
        }

        [HttpPut]
        public async ValueTask<ActionResult<Inventory>> PutInventoryAsync(Inventory inventory)
        {
            Inventory modifiedInventory = await this.inventoryService.ModifyInventoryAsync(inventory);

            return Ok(modifiedInventory);
        }

        [HttpDelete("{inventoryId}")]
        public async ValueTask<ActionResult<Inventory>> DeleteInventoryByIdAsync(Guid inventoryId)
        {
            Inventory removedInventory = await this.inventoryService.RemoveInventoryByIdAsync(inventoryId);

            return Ok(removedInventory);
        }
    }
}
