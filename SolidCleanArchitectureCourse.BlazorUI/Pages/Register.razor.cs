using Microsoft.AspNetCore.Components;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Models;

namespace SolidCleanArchitectureCourse.BlazorUI.Pages;

public partial class Register : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public IAuthenticationService AuthenticationService { get; set; } = null!;

    public RegisterVm Model { get; set; } = new();
    public string Message { get; set; } = "";

    protected async Task HandleRegister()
    {
        var success = await AuthenticationService.RegisterAsync(
            Model.FirstName, Model.LastName, Model.UserName, Model.Email, Model.Password);

        if (success)
        {
            NavigationManager.NavigateTo("/");
        }

        Message = "Something went wrong, please try again.";
    }
}
