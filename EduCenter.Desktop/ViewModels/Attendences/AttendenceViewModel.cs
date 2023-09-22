using EduCenter.Desktop.Entities;
using System;

namespace EduCenter.Desktop.ViewModels.Attendences;

public sealed class AttendenceViewModel : Auditable
{
    public long GroupId { get; set; }

    public string GroupName { get; set; } = string.Empty;

    public DateOnly LessonDate { get; set; }

    public string StudentFIO { get; set; } = String.Empty;

    public bool IsAttended { get; set; }

    public string Description { get; set; } = string.Empty;
}
