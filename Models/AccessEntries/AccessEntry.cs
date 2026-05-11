//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Inventories;
using Inventory_final_task_.Models.Users;

namespace Inventory_final_task_.Models.AccessEntries
{
    public class AccessEntry
    {
        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
