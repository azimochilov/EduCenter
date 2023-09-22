using System;
using System.ComponentModel.DataAnnotations;

namespace EduCenter.Desktop.Entities;

public abstract class Human : Auditable
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    [MaxLength(15)]
    public string ParentsPhoneNumber { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }

    public bool IsMale { get; set; }

    [MaxLength(9)]
    public string PassportSeriaNumber { get; set; } = String.Empty;

    public string Email { get; set; } = String.Empty;

    public string Address { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;
}
