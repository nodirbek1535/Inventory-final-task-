//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

namespace Inventory_final_task_.Brokers.Security
{
    public interface IHashBroker
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
