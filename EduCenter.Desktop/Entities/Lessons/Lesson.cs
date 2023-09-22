using System;

namespace EduCenter.Desktop.Entities.Lessons;

public sealed class Lesson : Auditable
{
    public long GroupId { get; set; }

    public long TeacherId { get; set; }

    public long RoomId { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateOnly DestinationDate { get; set; }

    public bool IsSuccessfull { get; set; }
}
