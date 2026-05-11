//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Users;

namespace Inventory_final_task_.Models.Comments
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid TargetId { get; set; }
        public Guid CreatedByUserId { get; set; }
        public User? CreatedByUser { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
