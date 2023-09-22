using EduCenter.Desktop.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduCenter.Desktop.Interfaces;

public interface IRepository<TEntity, TViewModel>
{
    public Task<int> CreateAsync(TEntity obj);

    public Task<int> UpdateAsync(long id, TEntity editedObj);

    public Task<int> DeleteAsync(long id);

    public Task<IList<TViewModel>> GetAllAsync(PaginationParams @params);

    public Task<TViewModel> GetAsync(long id);
}
