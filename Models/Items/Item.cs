//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Inventories;
using Inventory_final_task_.Models.Users;

namespace Inventory_final_task_.Models.Items
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public string CustomId { get; set; }
        public string StringField1 { get; set; }
        public string StringField2 { get; set; }
        public string StringField3 { get; set; }
        public decimal? NumberField1 { get; set; }
        public decimal? NumberField2 { get; set; }
        public decimal? NumberField3 { get; set; }
        public bool? BooleanField1 { get; set; }
        public bool? BooleanField2 { get; set; }
        public bool? BooleanField3 { get; set; }
        public Guid CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public int Version { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
