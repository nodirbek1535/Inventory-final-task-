//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

namespace Inventory_final_task_.Models.Inventories
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublic { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public int Version { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        //public ICollection<Item> Items { get; set; }
        //public ICollection<FieldConfiguration> FieldConfigurations { get; set; }
    }
