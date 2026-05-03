//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System;
using Inventory_final_task_.Models.Users;

namespace Inventory_final_task_.Models.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public string Language { get; set; } = "eng";
        public string Theme { get; set; } = "dark";
        public bool IsBlocked { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
