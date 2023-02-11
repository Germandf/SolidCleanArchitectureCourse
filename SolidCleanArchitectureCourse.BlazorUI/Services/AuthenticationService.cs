using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Providers;
using SolidCleanArchitectureCourse.BlazorUI.Services.Base;

namespace SolidCleanArchitectureCourse.BlazorUI.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(
        IClient client, 
        ILocalStorageService localStorage, 
        AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            var request = new AuthRequest { Email = email, Password = password };
            var response = await _client.LoginAsync(request);

            if (string.IsNullOrEmpty(response.Token) == false)
            {
                await _localStorage.SetItemAsync("token", response.Token);
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
                return true;
            }
        }
        catch (Exception)
        {

        }

        return false;
    }

    public async Task Logout()
    {
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
    {
        var request = new RegistrationRequest { 
            FirstName = firstName, LastName = lastName, UserName = userName, Email = email, Password = password };

        var response = await _client.RegisterAsync(request);

        if (string.IsNullOrEmpty(response.UserId) == false)
        {
            return true;
        }

        return false;
    }
}
