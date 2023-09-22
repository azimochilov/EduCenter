namespace EduCenter.Desktop.Entities.Teachers;

public sealed class Teacher : Human
{
    public long CourseId { get; set; }

    public string TeacherDegree { get; set; } = string.Empty;
}
