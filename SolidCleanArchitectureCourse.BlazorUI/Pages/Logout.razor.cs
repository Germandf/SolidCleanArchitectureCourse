using Microsoft.AspNetCore.Components;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages;

public partial class Logout
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await AuthenticationService.Logout();
        NavigationManager.NavigateTo("/");
    }
}