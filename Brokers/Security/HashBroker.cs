//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

namespace Inventory_final_task_.Brokers.Security
{
    public class HashBroker : IHashBroker
    {
        public string HashPassword(string password) =>
            BCrypt.Net.BCrypt.HashPassword(password);

        public bool VerifyPassword(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
