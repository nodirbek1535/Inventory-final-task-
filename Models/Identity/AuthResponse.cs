//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System;

namespace Inventory_final_task_.Models.Identity
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public DateTimeOffset ExpireAt { get; set; }
        public UserResponse User { get; set; }
    }
}
