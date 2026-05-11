using Inventory_final_task_.Models.IdElements;

namespace Inventory_final_task_.Services.Foundations.IdElements
{
    public interface IIdElementService
    {
        ValueTask<IdElement> AddIdElementAsync(IdElement idElement);
        IQueryable<IdElement> RetrieveAllIdElements();
        ValueTask<IdElement> RetrieveIdElementByIdAsync(Guid idElementId);
        ValueTask<IdElement> ModifyIdElementAsync(IdElement idElement);
        ValueTask<IdElement> RemoveIdElementByIdAsync(Guid idElementId);
    }
}
