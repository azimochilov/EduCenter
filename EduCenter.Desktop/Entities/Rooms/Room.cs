using System.ComponentModel.DataAnnotations;

namespace EduCenter.Desktop.Entities.Rooms;

public sealed class Room : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public short MaxCapacity { get; set; }

    public string Description { get; set; } = string.Empty;
}
