using System.ComponentModel.DataAnnotations;

namespace EduCenter.Desktop.Entities.Cources;

public sealed class Course : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string IntroVideoPath { get; set; } = string.Empty;

    public string IntroVideoThumb { get; set; } = string.Empty;
}
