//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System.Threading.Tasks;
using Inventory_final_task_.Models.Identity;

namespace Inventory_final_task_.Services.Orchestrations.Auth
{
    public interface IAuthService
    {
        ValueTask<UserResponse> RegisterAsync(RegisterRequest request);
        ValueTask<bool> ConfirmEmailAsync(string token);
        ValueTask<AuthResponse> LoginAsync(LoginRequest request);
    }
}
