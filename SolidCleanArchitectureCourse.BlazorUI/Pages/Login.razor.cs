using Microsoft.AspNetCore.Components;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Models;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages;

public partial class Login : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public IAuthenticationService AuthenticationService { get; set; } = null!;

    public LoginVm Model { get; set; } = new();
    public string Message { get; set; } = "";

    protected async Task HandleLogin()
    {
        if (await AuthenticationService.AuthenticateAsync(Model.Email, Model.Password))
        {
            NavigationManager.NavigateTo("/");
        }

        Message = "Username/password combination unknown";
    }
}
