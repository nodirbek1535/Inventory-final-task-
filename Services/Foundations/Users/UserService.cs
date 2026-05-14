using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Models.Users;

namespace Inventory_final_task_.Services.Foundations.Users
{
    public partial class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public UserService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<User> AddUserAsync(User user) =>
            this.storageBroker.InsertUserAsync(user);

        public IQueryable<User> RetrieveAllUsers() =>
            this.storageBroker.SelectAllUsers();

        public ValueTask<User> RetrieveUserByIdAsync(Guid userId) =>
            this.storageBroker.SelectUserByIdAsync(userId);

        public ValueTask<User> RetrieveUserByEmailAsync(string email) =>
            this.storageBroker.SelectUserByEmailAsync(email);

        public ValueTask<User> RetrieveUserByTokenAsync(string token) =>
            this.storageBroker.SelectUserByTokenAsync(token);

        public ValueTask<User> ModifyUserAsync(User user) =>
            this.storageBroker.UpdateUserAsync(user);

        public ValueTask<User> RemoveUserByIdAsync(Guid userId) =>
            this.storageBroker.DeleteUserAsync(new User { Id = userId });
    }
}
