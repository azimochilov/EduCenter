using EduCenter.Desktop.Enums;

namespace EduCenter.Desktop.Entities.Students;

public sealed class StudentPayment : Auditable
{
    public long GroupId { get; set; }

    public long StudentId { get; set; }

    public float Amount { get; set; }

    public PaymentType PaymentType { get; set; }

    public string Description { get; set; } = string.Empty;
}
