using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Providers;
using System.Runtime.CompilerServices;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages;

public partial class Index : ComponentBase
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
    
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    private IAuthenticationService AuthenticationService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await ((ApiAuthenticationStateProvider)AuthenticationStateProvider)
            .GetAuthenticationStateAsync();
    }

    private void GoToLogin()
    {
        NavigationManager.NavigateTo("login");
    }

    private void GoToRegister()
    {
        NavigationManager.NavigateTo("register");
    }

    private async void Logout()
    {
        await AuthenticationService.Logout();
    }
}