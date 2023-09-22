using EduCenter.Desktop.Enums;

namespace EduCenter.Desktop.Entities.Groups;

public sealed class GroupTeacher : Auditable
{
    public long GroupId { get; set; }

    public long TeacherId { get; set; }

    public float SalaryPerMonth { get; set; }

    public string Description { get; set; } = string.Empty;

    public TeacherStatus Status { get; set; }

    public string Role { get; set; } = string.Empty;
}
