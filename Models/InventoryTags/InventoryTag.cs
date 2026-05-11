//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Inventories;
using Inventory_final_task_.Models.Tags;

namespace Inventory_final_task_.Models.InventoryTags
{
    public class InventoryTag
    {
        public Guid Id { get; set; }

        public Guid InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

        public Guid TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
