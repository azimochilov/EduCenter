namespace EduCenter.Desktop.Entities.Attendences;

public sealed class Attendence : Auditable
{
    public long LessonId { get; set; }

    public long StudentId { get; set; }

    public bool IsAttended { get; set; }

    public string Description { get; set; } = string.Empty;
}
