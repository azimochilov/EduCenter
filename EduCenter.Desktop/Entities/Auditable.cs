using EduCenter.Desktop.Helpers;
using System;

namespace EduCenter.Desktop.Entities;

public abstract class Auditable : BaseEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Auditable()
    {
        CreatedAt = TimeHelper.GetDateTime();
        UpdatedAt = TimeHelper.GetDateTime();
    }
}
