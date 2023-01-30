using SolidCleanArchitectureCourse.Domain.Common;

namespace SolidCleanArchitectureCourse.Domain;

public class LeaveType : BaseEntity
{
    public string Name { get; set; } = "";
    public int DefaultDays { get; set; }
}
