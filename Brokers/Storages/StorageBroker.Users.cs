//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async ValueTask<User> InsertUserAsync(User user)
        {
            this.Users.Add(user);
            await this.SaveChangesAsync();

            return user;
        }

        IQueryable<User> IStorageBroker.SelectAllUsers() =>
            this.SelectAll<User>();

        public async ValueTask<User> SelectUserByIdAsync(Guid userId) =>
            await this.Users.FindAsync(userId);

        public async ValueTask<User> SelectUserByEmailAsync(string email) =>
            await this.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async ValueTask<User> SelectUserByTokenAsync(string token) =>
            await this.Users.FirstOrDefaultAsync(u => u.EmailConfirmationToken == token);

        public async ValueTask<User> UpdateUserAsync(User user)
        {
            this.Users.Update(user);
            await this.SaveChangesAsync();

            return user;
        }

        public async ValueTask<User> DeleteUserAsync(User user)
        {
            this.Users.Remove(user);
            await this.SaveChangesAsync();

            return user;
        }
    }
}
