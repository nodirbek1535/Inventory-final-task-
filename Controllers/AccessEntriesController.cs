using Microsoft.AspNetCore.Mvc;
using Inventory_final_task_.Models.AccessEntries;
using Inventory_final_task_.Services.Foundations.AccessEntries;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessEntriesController : RESTFulController
    {
        private readonly IAccessEntryService accessEntryService;

        public AccessEntriesController(IAccessEntryService accessEntryService) =>
            this.accessEntryService = accessEntryService;

        [HttpPost]
        public async ValueTask<ActionResult<AccessEntry>> PostAccessEntryAsync(AccessEntry accessEntry)
        {
            AccessEntry addedAccessEntry = await this.accessEntryService.AddAccessEntryAsync(accessEntry);

            return Created(addedAccessEntry);
        }

        [HttpGet]
        public ActionResult<IQueryable<AccessEntry>> GetAllAccessEntries()
        {
            IQueryable<AccessEntry> allAccessEntries = this.accessEntryService.RetrieveAllAccessEntries();

            return Ok(allAccessEntries);
        }

        [HttpGet("{accessEntryId}")]
        public async ValueTask<ActionResult<AccessEntry>> GetAccessEntryByIdAsync(Guid accessEntryId)
        {
            AccessEntry accessEntry = await this.accessEntryService.RetrieveAccessEntryByIdAsync(accessEntryId);

            return Ok(accessEntry);
        }

        [HttpPut]
        public async ValueTask<ActionResult<AccessEntry>> PutAccessEntryAsync(AccessEntry accessEntry)
        {
            AccessEntry modifiedAccessEntry = await this.accessEntryService.ModifyAccessEntryAsync(accessEntry);

            return Ok(modifiedAccessEntry);
        }

        [HttpDelete("{accessEntryId}")]
        public async ValueTask<ActionResult<AccessEntry>> DeleteAccessEntryByIdAsync(Guid accessEntryId)
        {
            AccessEntry removedAccessEntry = await this.accessEntryService.RemoveAccessEntryByIdAsync(accessEntryId);

            return Ok(removedAccessEntry);
        }
    }
}
