using Microsoft.AspNetCore.Mvc;
using Inventory_final_task_.Models.IdElements;
using Inventory_final_task_.Services.Foundations.IdElements;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdElementsController : RESTFulController
    {
        private readonly IIdElementService idElementService;

        public IdElementsController(IIdElementService idElementService) =>
            this.idElementService = idElementService;

        [HttpPost]
        public async ValueTask<ActionResult<IdElement>> PostIdElementAsync(IdElement idElement)
        {
            IdElement addedIdElement = await this.idElementService.AddIdElementAsync(idElement);

            return Created(addedIdElement);
        }

        [HttpGet]
        public ActionResult<IQueryable<IdElement>> GetAllIdElements()
        {
            IQueryable<IdElement> allIdElements = this.idElementService.RetrieveAllIdElements();

            return Ok(allIdElements);
        }

        [HttpGet("{idElementId}")]
        public async ValueTask<ActionResult<IdElement>> GetIdElementByIdAsync(Guid idElementId)
        {
            IdElement idElement = await this.idElementService.RetrieveIdElementByIdAsync(idElementId);

            return Ok(idElement);
        }

        [HttpPut]
        public async ValueTask<ActionResult<IdElement>> PutIdElementAsync(IdElement idElement)
        {
            IdElement modifiedIdElement = await this.idElementService.ModifyIdElementAsync(idElement);

            return Ok(modifiedIdElement);
        }

        [HttpDelete("{idElementId}")]
        public async ValueTask<ActionResult<IdElement>> DeleteIdElementByIdAsync(Guid idElementId)
        {
            IdElement removedIdElement = await this.idElementService.RemoveIdElementByIdAsync(idElementId);

            return Ok(removedIdElement);
        }
    }
}
