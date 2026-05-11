//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================


using Inventory_final_task_.Models.IdElements;

namespace Inventory_final_task_.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<IdElement> InsertIdElementAsync(IdElement idElement);
        IQueryable<IdElement> SelectAllIdElements();
        ValueTask<IdElement> SelectIdElementByIdAsync(Guid idElementId);
        ValueTask<IdElement> UpdateIdElementAsync(IdElement idElement);
        ValueTask<IdElement> DeleteIdElementAsync(IdElement idElement);
    }
}
