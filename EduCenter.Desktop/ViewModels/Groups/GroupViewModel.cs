using EduCenter.Desktop.Entities;
using EduCenter.Desktop.Enums;
using System;

namespace EduCenter.Desktop.ViewModels.Groups;

public class GroupViewModel : Auditable
{
    public string Name { get; set; } = String.Empty;

    public int CountStudents { get; set; }

    public short MaxCapacity { get; set; }

    public short MinCapacity { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public GroupStatus Status { get; set; }

    public string Description { get; set; } = String.Empty;

    public float PricePerMonth { get; set; }

    public bool IsOnline { get; set; }

}
