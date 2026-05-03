//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Inventories;

namespace Inventory_final_task_.Models.IdElements
{
    public class IdElement
    {
        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public string ElementType { get; set; }
        public string FixedTextVsalue { get; set; }
        public string FormatOptions { get; set; }
        public int DisplayOrder { get; set; }
    }
}
