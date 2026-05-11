using Microsoft.AspNetCore.Mvc;
using Inventory_final_task_.Models.Users;
using Inventory_final_task_.Services.Foundations.Users;
using RESTFulSense.Controllers;

namespace Inventory_final_task_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : RESTFulController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService) =>
            this.userService = userService;

        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUserAsync(User user)
        {
            User addedUser = await this.userService.AddUserAsync(user);

            return Created(addedUser);
        }

        [HttpGet]
        public ActionResult<IQueryable<User>> GetAllUsers()
        {
            IQueryable<User> allUsers = this.userService.RetrieveAllUsers();

            return Ok(allUsers);
        }

        [HttpGet("{userId}")]
        public async ValueTask<ActionResult<User>> GetUserByIdAsync(Guid userId)
        {
            User user = await this.userService.RetrieveUserByIdAsync(userId);

            return Ok(user);
        }

        [HttpPut]
        public async ValueTask<ActionResult<User>> PutUserAsync(User user)
        {
            User modifiedUser = await this.userService.ModifyUserAsync(user);

            return Ok(modifiedUser);
        }

        [HttpDelete("{userId}")]
        public async ValueTask<ActionResult<User>> DeleteUserByIdAsync(Guid userId)
        {
            User removedUser = await this.userService.RemoveUserByIdAsync(userId);

            return Ok(removedUser);
        }
    }
}
