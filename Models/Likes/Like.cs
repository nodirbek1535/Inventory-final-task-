//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.Users;

namespace Inventory_final_task_.Models.Likes
{
    public class Like
    {
        public Guid Id { get; set; }
        public Guid TargetId { get; set; }
        public Guid UserId{ get; set; }
        public User User { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
