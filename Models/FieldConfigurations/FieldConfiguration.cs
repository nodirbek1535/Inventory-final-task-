//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Inventories;

namespace Inventory_final_task_.Models.FieldConfigurations
{
    public class FieldConfiguration
    {
        public Guid Guid { get; set; }
        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public string FieldType { get; set; }
        public int SlotIndex { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsVisibleInTable { get; set; }
        public int DisplayOrder { get; set; }
    }
}
