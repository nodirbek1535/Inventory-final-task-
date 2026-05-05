//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


namespace Inventory_final_task_.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTimeOffset() =>
            DateTimeOffset.UtcNow;
    }
}
