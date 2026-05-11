using Microsoft.AspNetCore.Mvc;
using Inventory_final_task_.Models.FieldConfigurations;
using Inventory_final_task_.Services.Foundations.FieldConfigurations;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldConfigurationsController : RESTFulController
    {
        private readonly IFieldConfigurationService fieldConfigurationService;

        public FieldConfigurationsController(IFieldConfigurationService fieldConfigurationService) =>
            this.fieldConfigurationService = fieldConfigurationService;

        [HttpPost]
        public async ValueTask<ActionResult<FieldConfiguration>> PostFieldConfigurationAsync(FieldConfiguration fieldConfiguration)
        {
            FieldConfiguration addedFieldConfiguration = await this.fieldConfigurationService.AddFieldConfigurationAsync(fieldConfiguration);

            return Created(addedFieldConfiguration);
        }

        [HttpGet]
        public ActionResult<IQueryable<FieldConfiguration>> GetAllFieldConfigurations()
        {
            IQueryable<FieldConfiguration> allFieldConfigurations = this.fieldConfigurationService.RetrieveAllFieldConfigurations();

            return Ok(allFieldConfigurations);
        }

        [HttpGet("{fieldConfigurationId}")]
        public async ValueTask<ActionResult<FieldConfiguration>> GetFieldConfigurationByIdAsync(Guid fieldConfigurationId)
        {
            FieldConfiguration fieldConfiguration = await this.fieldConfigurationService.RetrieveFieldConfigurationByIdAsync(fieldConfigurationId);

            return Ok(fieldConfiguration);
        }

        [HttpPut]
        public async ValueTask<ActionResult<FieldConfiguration>> PutFieldConfigurationAsync(FieldConfiguration fieldConfiguration)
        {
            FieldConfiguration modifiedFieldConfiguration = await this.fieldConfigurationService.ModifyFieldConfigurationAsync(fieldConfiguration);

            return Ok(modifiedFieldConfiguration);
        }

        [HttpDelete("{fieldConfigurationId}")]
        public async ValueTask<ActionResult<FieldConfiguration>> DeleteFieldConfigurationByIdAsync(Guid fieldConfigurationId)
        {
            FieldConfiguration removedFieldConfiguration = await this.fieldConfigurationService.RemoveFieldConfigurationByIdAsync(fieldConfigurationId);

            return Ok(removedFieldConfiguration);
        }
    }
}
