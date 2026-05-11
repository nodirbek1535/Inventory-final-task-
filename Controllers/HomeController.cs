using Microsoft.AspNetCore.Mvc;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get() => "InvenTrack API is running!";
    }
}
