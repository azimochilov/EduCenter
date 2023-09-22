using EduCenter.Desktop.Entities.Attendences;
using EduCenter.Desktop.ViewModels.Attendences;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduCenter.Desktop.Interfaces.Attendences;

public interface IAttendenceRepository : IRepository<Attendence, AttendenceViewModel>
{
    public Task<IList<AttendenceViewModel>> GetByDateAsync(long groupId, DateOnly date);
}
