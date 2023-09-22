using EduCenter.Desktop.Entities.Groups;
using EduCenter.Desktop.ViewModels.Groups;
using System.Threading.Tasks;

namespace EduCenter.Desktop.Interfaces.Groups;

public interface IGroupRepository : IRepository<Group, GroupViewModel>
{
    public Task<int> GetLatestGroupNumberByCourseAsync(long courseId);
}
