using Microsoft.AspNetCore.Components;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Models.LeaveTypes;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages.LeaveTypes;

public partial class Index
{
    [Inject]
    public required NavigationManager NavigationManager { get; set; }
    [Inject]
    public required ILeaveAllocationService LeaveAllocationService { get; set; }
    [Inject]
    public required ILeaveTypeService LeaveTypeService { get; set; }

    public List<LeaveTypeVm>? LeaveTypes { get; private set; }
    public string Message { get; set; } = "";
    
    protected void CreateLeaveType()
    {
        NavigationManager.NavigateTo("/leavetypes/create");
    }

    protected void AllocateLeaveType(int id)
    {
        LeaveAllocationService.CreateLeaveAllocations(id);
    }

    protected void EditLeaveType(int id)
    {
        NavigationManager.NavigateTo($"/leavetypes/edit/{id}");
    }

    protected void DetailsLeaveType(int id)
    {
        NavigationManager.NavigateTo($"/leavetypes/details/{id}");
    }

    protected async void DeleteLeaveType(int id)
    {
        var response = await LeaveTypeService.DeleteLeaveType(id);
        if (response.Success)
        {
            StateHasChanged();
        }
        else
        {
            Message = response.Message;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        LeaveTypes = await LeaveTypeService.GetLeaveTypes();
    }
}
