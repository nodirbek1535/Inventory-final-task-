//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System.Threading.Tasks;
using Inventory_final_task_.Brokers.Emails;

namespace Inventory_final_task_.Services.Foundations.Emails
{
    public class EmailService : IEmailService
    {
        private readonly IEmailBroker emailBroker;

        public EmailService(IEmailBroker emailBroker) =>
            this.emailBroker = emailBroker;

        public async ValueTask SendVerificationEmailAsync(string email, string userName, string token)
        {
            string subject = "InvenTrack - Emailni tasdiqlash";
            
            string body = $@"
                <h1>Salom, {userName}!</h1>
                <p>InvenTrack tizimida ro'yxatdan o'tganingiz uchun rahmat.</p>
                <p>Email manzilingizni tasdiqlash uchun quyidagi tokendan foydalaning:</p>
                <h2 style='color:blue;'>{token}</h2>
                <p>Yoki ushbu linkni bosing: <a href='https://localhost:7194/api/Auth/confirm-email?token={token}'>Tasdiqlash</a></p>
            ";

            await this.emailBroker.SendEmailAsync(email, subject, body);
        }
    }
}
