using System;

namespace EduCenter.Desktop.Entities.Groups;

public sealed class GroupDetail : Auditable
{
    public long GroupId { get; set; }

    public long RoomId { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string Description { get; set; } = String.Empty;
}
