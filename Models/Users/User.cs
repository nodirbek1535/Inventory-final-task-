//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System;

namespace Inventory_final_task_.Models.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public UserStatus Status { get; set; } = UserStatus.Unverified;
        public string Language { get; set; } = "eng";
        public string Theme { get; set; } = "dark";
        public bool IsBlocked { get; set; }
        public DateTimeOffset? LastLoginTime { get; set; }
        public string? EmailConfirmationToken { get; set; }
        public DateTimeOffset? TokenExpiresAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
