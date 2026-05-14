//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System.Threading.Tasks;

namespace Inventory_final_task_.Brokers.Emails
{
    public interface IEmailBroker
    {
        ValueTask SendEmailAsync(string receiverAddress, string subject, string body);
    }
}
