//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System.Threading.Tasks;

namespace Inventory_final_task_.Services.Foundations.Emails
{
    public interface IEmailService
    {
        ValueTask SendVerificationEmailAsync(string email, string userName, string token);
    }
}
