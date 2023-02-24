namespace SolidCleanArchitectureCourse.BlazorUI.Models.LeaveAllocations;

public class ViewLeaveAllocationsVm
{
    public string EmployeeId { get; set; } = "";

    public List<LeaveAllocationVm> LeaveAllocations { get; set; } = new();
}
