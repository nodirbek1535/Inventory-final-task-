//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

namespace Inventory_final_task_.Services.Foundations.Security
{
    public interface IPasswordHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
