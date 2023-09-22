namespace EduCenter.Desktop.Entities.Employees;

public sealed class Employee : Human
{
    public long PositionId { get; set; }

    public float SalaryPerMonth { get; set; }
}
