using EduCenter.Desktop.Enums;
using System;

namespace EduCenter.Desktop.Entities.Groups;

public sealed class Group : Auditable
{
    public long CourseId { get; set; }

    public short Number { get; set; }

    public string Type { get; set; } = String.Empty;

    public short MaxCapacity { get; set; }

    public short MinCapacity { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public GroupStatus Status { get; set; }

    public string Description { get; set; } = String.Empty;

    public float PricePerMonth { get; set; }

    public bool IsOnline { get; set; }
}
