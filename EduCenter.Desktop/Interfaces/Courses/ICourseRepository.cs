using EduCenter.Desktop.Entities.Cources;
using System.Threading.Tasks;

namespace EduCenter.Desktop.Interfaces.Courses;

public interface ICourseRepository : IRepository<Course, Course>
{
    public Task<int> CountAsync();
}
