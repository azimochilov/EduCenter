using EduCenter.Desktop.Enums;
using System;

namespace EduCenter.Desktop.Entities.Groups;

public sealed class GroupStudent : Auditable
{
    public long GroupId { get; set; }

    public long StudentId { get; set; }

    public DateOnly PaymentDate { get; set; }
    
    public string Description { get; set; } = String.Empty;

    public float PricePerMonth { get; set; }

    public StudentStatus Status { get; set; }
}
