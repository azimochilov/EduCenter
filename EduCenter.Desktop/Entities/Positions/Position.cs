using System.ComponentModel.DataAnnotations;

namespace EduCenter.Desktop.Entities.Positions;

public sealed class Position : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
