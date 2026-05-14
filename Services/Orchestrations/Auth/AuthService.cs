//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System;
using System.Threading.Tasks;
using Inventory_final_task_.Models.Identity;
using Inventory_final_task_.Models.Users;
using Inventory_final_task_.Services.Foundations.Emails;
using Inventory_final_task_.Services.Foundations.Security;
using Inventory_final_task_.Services.Foundations.Users;

namespace Inventory_final_task_.Services.Orchestrations.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserService userService;
        private readonly IPasswordHashService passwordHashService;
        private readonly ITokenService tokenService;
        private readonly IEmailService emailService;

        public AuthService(
            IUserService userService,
            IPasswordHashService passwordHashService,
            ITokenService tokenService,
            IEmailService emailService)
        {
            this.userService = userService;
            this.passwordHashService = passwordHashService;
            this.tokenService = tokenService;
            this.emailService = emailService;
        }

        public async ValueTask<UserResponse> RegisterAsync(RegisterRequest request)
        {
            string confirmationToken = this.tokenService.GenerateEmailConfirmationToken();

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = this.passwordHashService.HashPassword(request.Password),
                Role = UserRole.User,
                Status = UserStatus.Unverified,
                EmailConfirmationToken = confirmationToken,
                TokenExpiresAt = this.tokenService.GetTokenExpirationTime(),
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            var createdUser = await this.userService.AddUserAsync(user);

            // Emailni async jo'natamiz (fire-and-forget)
            _ = Task.Run(async () =>
            {
                try
                {
                    await this.emailService.SendVerificationEmailAsync(
                        createdUser.Email,
                        createdUser.UserName,
                        createdUser.EmailConfirmationToken);
                }
                catch { /* Email xatosi registratsiyani to'xtatmaydi */ }
            });

            return new UserResponse
            {
                Id = createdUser.Id,
                UserName = createdUser.UserName,
                Email = createdUser.Email
            };
        }

        public async ValueTask<bool> ConfirmEmailAsync(string token)
        {
            var user = await this.userService.RetrieveUserByTokenAsync(token);

            if (user == null || user.TokenExpiresAt < DateTimeOffset.UtcNow)
                return false;

            if (user.Status == UserStatus.Unverified)
                user.Status = UserStatus.Active;

            user.EmailConfirmationToken = null;
            await this.userService.ModifyUserAsync(user);

            return true;
        }

        public async ValueTask<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await this.userService.RetrieveUserByEmailAsync(request.Email);

            if (user == null)
                throw new Exception("Foydalanuvchi topilmadi!");

            bool isPasswordValid = 
                this.passwordHashService.VerifyPassword(request.Password, user.PasswordHash);

            if (!isPasswordValid)
                throw new Exception("Parol noto'g'ri!");

            if (user.Status == UserStatus.Unverified)
                throw new Exception("Iltimos, avval email manzilingizni tasdiqlang!");

            if (user.IsBlocked || user.Status == UserStatus.Blocked)
                throw new Exception("Akkauntingiz bloklangan!");

            user.LastLoginTime = DateTimeOffset.UtcNow;
            await this.userService.ModifyUserAsync(user);

            string token = this.tokenService.GenerateJwtToken(user);

            return new AuthResponse
            {
                Token = token,
                ExpireAt = DateTimeOffset.UtcNow.AddMinutes(1440),
                User = new UserResponse
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                }
            };
        }
    }
}
