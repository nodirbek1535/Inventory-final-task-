//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using Inventory_final_task_.Brokers.Security;

namespace Inventory_final_task_.Services.Foundations.Security
{
    public class PasswordHashService : IPasswordHashService
    {
        private readonly IHashBroker hashBroker;

        public PasswordHashService(IHashBroker hashBroker) =>
            this.hashBroker = hashBroker;

        public string HashPassword(string password) =>
            this.hashBroker.HashPassword(password);

        public bool VerifyPassword(string password, string hashedPassword) =>
            this.hashBroker.VerifyPassword(password, hashedPassword);
    }
}
