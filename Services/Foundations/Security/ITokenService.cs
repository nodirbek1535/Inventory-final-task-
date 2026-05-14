//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System;
using Inventory_final_task_.Models.Users;

namespace Inventory_final_task_.Services.Foundations.Security
{
    public interface ITokenService
    {
        string GenerateEmailConfirmationToken();
        DateTimeOffset GetTokenExpirationTime();
        string GenerateJwtToken(User user);
    }
}
